import { useEffect, useMemo, useRef, useState } from 'react'
import { useParams } from 'react-router'
import { useReduxDispatch } from '../redux'
import { post } from '../redux/results'
import { get } from '../redux/surveys'
import { Model } from 'survey-core'
import { Survey } from 'survey-react-ui'
import 'survey-core/survey-core.css'
import { createRoot } from 'react-dom/client'
import MyCustomButton from '../components/MyCustomButton'
import UserStatusContainer from '../components/UserStatusContainer'
import '../pages/Run.css';
import { Mode } from 'fs'

const Run = () => {
    const dispatch = useReduxDispatch()
    const { id } = useParams();
    const [surveyData, surveyDataSet] = useState<any>(null)
    const [surveyModel, surveyModelSet] = useState<Model>()
    const [userInfo, userInfoSet] = useState<{ userName: string; date: string }>({ userName: "John Doe", date: new Date().toLocaleDateString() });
    const surveyModelRef = useRef<Model | null>(null);// this is for outside useEffect access

    useEffect(() => {
        (async () => {
            const surveyAction = await dispatch(get(id as string))
            surveyDataSet(surveyAction.payload)

            const model = new Model(surveyAction.payload?.json);
            model
                .onComplete
                .add((sender: Model) => {
                    dispatch(post({ postId: id as string, surveyResult: sender.data, surveyResultText: JSON.stringify(sender.data) }))
                });
            surveyModelSet(model);
            surveyModelRef.current = model;

            model.onAfterRenderQuestion.add((survey, options) => {
                console.log("Question rendered: " + options.question.name);


                //if (options.question?.getType() !== "comment") return;

                survey.setValue(`status_${options.question.name}`, "Idle");


                

                if (!options.htmlElement.querySelector(".user-status-container")) {

                    const container = document.createElement("div");
                    container.className = "user-status-container";
                    container.style.marginTop = "12px";

                    options.htmlElement.appendChild(container);

                    const root = createRoot(container);
                    root.render(<>
                        <UserStatusContainer userInfo={userInfo} survey={survey} option={options} />
                        <MyCustomButton question={options.question} survey={survey} />
                    </>);
                }

                // const el = options.htmlElement;
                // el.classList.add("question-container-lock");

                //lock and unlock question simulation
                const el = options.htmlElement;
                el.classList.add("question-container-lock");
                // avoid duplicates
                if (el.querySelector(".lock-icon")) return;

                const lock = document.createElement("span");
                lock.className = "lock-icon";
                lock.innerHTML = "🔒"; // or SVG

                el.prepend(lock);

                // // initial state
                // toggleReadonlyUI(options.question, el);

                // // react to readonly changes
                // options.question.readOnlyChangedCallback = () => {
                //     toggleReadonlyUI(options.question, el);
                // };

            });

            model.onValueChanged.add((survey, options) => {
                console.log("Value changed: " + options.name + " = " + options.value);
                if (options?.question?.getType() === "comment") {
                    console.log("comment question values: " + options.question.value);
                    survey?.setValue(options.name, options.value + " - changed!", true);
                }
            });

        })()
    }, [dispatch, id])

    const toggleReadonlyUI = (question: any, el: HTMLElement) => {
        if (question.readOnly) {
            el.classList.add("question-readonly");
        } else {
            el.classList.remove("question-readonly");
        }
    };


    //external event to update comment question
    const updateComment = (qKey: string, value: unknown) => {
        const model = surveyModelRef.current;
        if (!model) return;
        userInfoSet({ userName: "Jane Smith", date: new Date().toLocaleDateString() });



        //update the question value from socket or other external event
        model.setValue("suggestions", "I run changed you!", true);

        //update the status to show locked by Run component
        model.setValue(`status_${qKey}`, "Updated by Run Component");

        //disbale the question
        const question = model.getQuestionByName(qKey);
        if (question) {
            question.readOnly = true;
        }
    };

    // updateComment("", "");




    return (<>
        {surveyData === null && <div>Loading...</div>}
        {surveyData === undefined && <div>Survey not found</div>}
        {!!surveyData && !!surveyModel && !surveyModel.title && <>
            <h1>{surveyData.name}</h1>
        </>}
        {!!surveyModel && <>
            <Survey model={surveyModel} />
            <button onClick={() => updateComment("Quality", "I run changed you!")}>Update Comment</button>
        </>}
    </>);
}
// suggestions
export default Run;