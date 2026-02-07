import { Model,Question } from 'survey-core'

const MyCustomButton = ({ question,survey }: { question: Question, survey: Model }) => {
  const handleClick = () => {
    survey.setValue(
      question.name,
      "Updated from button"
    );
  };

  return <button onClick={handleClick}>Update</button>;
};

export default MyCustomButton;