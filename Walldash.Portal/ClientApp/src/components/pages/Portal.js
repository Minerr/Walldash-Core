import React, { useState, useEffect } from "react";
import NewDashboardButton from "../NewDashboardButton";
import DashboardPreview from "../DashboardPreview";
import ApiClient from "../../api/ApiClient";

const Portal = () => {
  const [dashboards, setDashboards] = useState([]);

  useEffect(() => {
    ApiClient.getDashboards().then(response => {
      setDashboards(response);
    });
  }, []);

  const handleSubmit = title => {
    ApiClient.createDashboard(title).then(response => {
      setDashboards([...dashboards, { alias: title, id: response }]);
    });
  };

  const handleUpdate = (title, id) => {
    ApiClient.updateDashboard(id, title).then(response => {
      const data = [...dashboards];
      const index = data.findIndex(d => d.id === id);
      data[index].alias = title;

      setDashboards(data);
    });
  };

  const handleRemove = id => {
    ApiClient.deleteDashboard(id).then(response => {
      setDashboards(dashboards.filter(d => d.id !== id));
    });
  };

  return (
    <div className='portal'>
      {dashboards.map(dashboard => {
        return (
          <DashboardPreview key={dashboard.id} dashboard={dashboard} onSubmit={handleUpdate} onRemove={handleRemove} />
        );
      })}
      <NewDashboardButton onSubmit={handleSubmit} />
    </div>
  );
};

export default Portal;
