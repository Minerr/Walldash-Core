import React, { createContext, useEffect } from "react";
import { widgetReducer } from "../reducers/widgetReducer";
import useAsyncReducer from "../reducers/useAsyncReducer";

export const WidgetContext = createContext();

const WidgetContextProvider = props => {
  const [widgets, dispatch] = useAsyncReducer(widgetReducer, []);

  useEffect(() => {
    dispatch({ type: "INIT_FETCH", dashboardId: props.dashboardId });
  }, []);

  return (
    <WidgetContext.Provider value={{ widgets, dispatch }}>
      {props.children}
    </WidgetContext.Provider>
  );
};

export default WidgetContextProvider;
