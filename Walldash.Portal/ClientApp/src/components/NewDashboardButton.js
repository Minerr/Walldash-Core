import React, { useState } from "react";

const NewDashboardButton = ({ onSubmit }) => {
  const [title, setTitle] = useState("");
  const [formActive, setFormActive] = useState(false);

  const renderDisplay = () => {
    return (
      <div
        className="new-dashboard-button"
        onClick={() => setFormActive(true)}
      />
    );
  };

  const renderForm = () => {
    return (
      <div className="new-dashboard-form">
        <form
          onSubmit={e => {
            e.preventDefault();
            onSubmit(title);
            setFormActive(false);
          }}
        >
          <input
            type="text"
            placeholder="Title"
            onChange={e => setTitle(e.target.value)}
            value={title}
            required
          />
          <input type="submit" value="save" />
        </form>
        <button onClick={() => setFormActive(false)}>cancel</button>
      </div>
    );
  };

  return formActive ? renderForm() : renderDisplay();
};

export default NewDashboardButton;
