import { useEffect, useState } from 'react';
import IUserInfo from '../models/IUserInfo';

const UserStatusContainer = ({userInfo, survey, option}: {userInfo: IUserInfo, survey: any, option: any}) => {
  const key = `status_${option.question.name}`;

  const [status, setStatus] = useState(
    survey.getValue(key) || "Idle"
  );

  useEffect(() => {
    const handler = (_: any, opt: any) => {
      if (opt.name === key) {
        setStatus(opt.value);
        userInfo.userName = opt.value.userName;
        userInfo.date = opt.value.date;
      }
    };

    survey.onValueChanged.add(handler);
    return () => survey.onValueChanged.remove(handler);
  }, [survey, key]);

  // survey.onValueChanged.add((s: any, o: any) => {
  //   if (o.name === "userStatus") {
  //     userInfo.userName = o.value.userName;
  //     userInfo.date = o.value.date;
  //   }
  // });

  return <>
    <div id='UserContainer'>
      <div id='lockMsg'>Locked by Admin: {status}</div>
      <div id='userStatus'>
        <span id='userName'>User: {userInfo.userName}</span>
        <span id='userDate'>Date: {userInfo.date}</span>
      </div>
    </div>
  </>
};

export default UserStatusContainer;