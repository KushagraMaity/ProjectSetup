const About = () => (<div className='sjs-client-app__content--about'>
    <h1>About</h1>
    <article className="markdown-body entry-content container-lg">
        <p dir="auto">This project is a client-side React application that uses <a href="https://surveyjs.io/" rel="nofollow">SurveyJS</a> components. The application displays a list of surveys with the following buttons that perform actions on the surveys:</p>
        <ul dir="auto">
            <li><strong>Run</strong> - Uses the <a href="https://surveyjs.io/form-library/documentation/overview" rel="nofollow">SurveyJS Form Library</a> component to run the survey.</li>
            <li><strong>Edit</strong> - Uses the <a href="https://surveyjs.io/survey-creator/documentation/overview" rel="nofollow">Survey Creator</a> component to configure the survey.</li>
            <li><strong>Results</strong> - Uses the <a href="https://surveyjs.io/dashboard/documentation/overview" rel="nofollow">SurveyJS Dashboard</a> component to display survey results as a table.</li>
            <li><strong>Remove</strong> - Deletes the survey.</li>
        </ul>
        <p dir="auto"><a target="_blank" rel="noopener noreferrer nofollow" href="https://user-images.githubusercontent.com/18551316/183420903-7fbcc043-5833-46fe-9910-5aa451045119.png"><img src="https://user-images.githubusercontent.com/18551316/183420903-7fbcc043-5833-46fe-9910-5aa451045119.png" alt="My Surveys App" style={{maxWidth: "100%"}}/></a></p>
        <p dir="auto">You can integrate this project with a backend of your choice to create a full-cycle survey management service as shown in the following repos:</p>
        <ul dir="auto">
            <li><a href="https://github.com/surveyjs/surveyjs-aspnet-mvc">surveyjs-aspnet-mvc</a></li>
            <li><a href="https://github.com/surveyjs/surveyjs-nodejs">surveyjs-nodejs</a></li>
            <li><a href="https://github.com/surveyjs/surveyjs-php">surveyjs-php</a></li>
        </ul>
    </article>
</div>)

export default About;