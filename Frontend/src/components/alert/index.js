import React from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { alertErrorSetting } from './alertSetting'

export default function ErrorAlert({data, setErrors}) {

  let text = "";
  for (let key in data) {
    text += data[key] + " ";
  }
  
 setErrors();
 
 const clearWaitingQueue = () => {
  toast.clearWaitingQueue();
}
 const notify = () => toast.error(text, alertErrorSetting);
  return (
    <div>
      {text == "" ? null : notify()}
      {clearWaitingQueue()}
    </div>
  );
}
