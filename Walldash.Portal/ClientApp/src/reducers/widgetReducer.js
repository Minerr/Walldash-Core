import fakeApi from "../fakeApi";
import uuid from "uuid/v4";
import ApiClient from "../api/ApiClient";

const initialState = [];

export const widgetReducer = async (state = initialState, action) => {
  return new Promise(resolve => {
    switch (action.type) {
      case "INIT_FETCH":
        ApiClient.getWidgets(action.dashboardId).then(response => {
          resolve(response);
        });
        break;

      case "ADD_WIDGET":
        const widget = action.widget;
        delete widget.metricData;

        ApiClient.createWidget(widget).then(response => {
          resolve([...state, { ...action.widget, id: response }]);
        });
        break;

      case "REFRESH_WIDGET": {
        const { id, metricAlias } = action;
        const response = fakeApi.getAllByAlias(metricAlias);
        const widgets = [...state];
        const objIndex = widgets.findIndex(obj => obj.id === id);
        widgets[objIndex].metricData = response.data;

        resolve(widgets);
        break;
      }

      case "UPDATE_WIDGET": {
        const widget = action.widget;
        delete widget.metricData;

        ApiClient.updateWidget(action.id, widget).then(response => {
          const widgets = [...state];
          const objIndex = widgets.findIndex(obj => obj.id === action.id);

          const data = fakeApi.getAllByAlias(widget.metricAlias).data;

          widgets[objIndex] = { ...action.widget };
          widgets[objIndex].metricData = data;

          resolve(widgets);
        });
        break;
      }

      case "REMOVE_WIDGET": {
        ApiClient.deleteWidget(action.id).then(response => {
          resolve(state.filter(w => w.id !== action.id));
        });
        break;
      }

      default:
        resolve(state);
    }
  });
};
