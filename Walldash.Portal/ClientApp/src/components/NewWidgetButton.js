import React, { useState } from "react";
import WidgetForm from "./widgets/forms/WidgetForm";

const NewWidgetButton = ({ onClick }) => {
  const [formActive, setFormActive] = useState(false);
  return (
    <React.Fragment>
      <div className='base-widget'>
        <div className='aspec-ratio'>
          <div onClick={() => setFormActive(true)} className='new-widget-button'></div>
        </div>
      </div>
      {formActive ? <WidgetForm onClose={() => setFormActive(false)} initCreate={true} /> : ""}
    </React.Fragment>
  );
};

export default NewWidgetButton;
