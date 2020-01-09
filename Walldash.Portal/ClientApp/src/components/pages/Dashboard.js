import React, { useEffect, useContext } from "react";
import WidgetList from "../WidgetList";
import WidgetContextProvider from "../../contexts/WidgetContext";
const Dashboard = props => {
  return (
    <div className='dashboard'>
      <WidgetContextProvider dashboardId={props.match.params.id}>
        <WidgetList />
      </WidgetContextProvider>
    </div>
  );
};

export default Dashboard;
