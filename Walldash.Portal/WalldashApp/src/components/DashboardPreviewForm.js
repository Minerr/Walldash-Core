import React, { useState } from "react";

const DashboardPreviewForm = ({ onSubmit, onEdit, onRemove, dashboard }) => {
  const [title, setTitle] = useState("");

  return (
    <div className="edit">
      <form
        onSubmit={e => {
          e.preventDefault();
          onSubmit(title, dashboard.id);
          onEdit();
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
      <button className="cancel-edit" onClick={onEdit}>
        cancel
      </button>
      <button
        className="delete-dashboard"
        onClick={() => onRemove(dashboard.id)}
      >
        Delete
      </button>
    </div>
  );
};

export default DashboardPreviewForm;
