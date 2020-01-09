import React, { useState } from "react";
import { Link } from "react-router-dom";
import DashboardPreviewForm from "./DashboardPreviewForm";

const DashboardPreview = ({ dashboard, onSubmit, onRemove }) => {
  const [edit, setEdit] = useState(false);

  const renderDisplay = () => {
    return (
      <React.Fragment>
        <Link to={`/dashboard/${dashboard.id}`}>
          <div className='title'>{dashboard.alias}</div>
        </Link>
        <div className='btn-edit' onClick={() => setEdit(true)}>
          edit
        </div>
      </React.Fragment>
    );
  };

  const renderEdit = () => {
    return (
      <DashboardPreviewForm
        onEdit={() => setEdit(false)}
        onSubmit={onSubmit}
        onRemove={onRemove}
        dashboard={dashboard}
      />
    );
  };

  return <div className={`dashboard-preview ${edit ? "" : "pointer"}`}>{edit ? renderEdit() : renderDisplay()}</div>;
};

export default DashboardPreview;
