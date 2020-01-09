import React, { useState, useContext, useEffect } from "react";
import WidgetTypeSelect from "./WidgetTypeSelect";
import { WidgetContext } from "../../../contexts/WidgetContext";
import SingleDataForm from "./SingleDataForm";
import GraphForm from "./GraphForm";
import { useParams } from "react-router";
import CustomInput from "./CustomInput";
import CustomSelect from "./CustomSelect";
import TagSelector from "../../patials/TagSelector";
import ColorPicker from "../../patials/ColorPicker";

const WidgetForm = ({ onClose, initCreate = false, widget }) => {
  const dashboardId = parseInt(useParams().id);

  const { dispatch } = useContext(WidgetContext);
  const [widgetChanges, setWidgetChanges] = useState({
    id: 0,
    dashboardId: dashboardId,
    type: "",
    alias: "",
    width: 1,
    height: 1,
    metricAlias: "",
    metricData: [],
    tags: [],
    backgroundColor: "#fff",
    textColor: "#000",
    graphColor: "blue",
    graphValueX: "",
    graphValueY: ""
  });

  useEffect(() => {
    setInitState();
  }, []);

  const setInitState = () => {
    if (!initCreate) {
      setWidgetChanges(widget);
    }
  };

  const handleRemoveWidget = () => {
    dispatch({ type: "REMOVE_WIDGET", id: widgetChanges.id });
    onClose();
  };

  const handleUpdateWidget = () => {
    dispatch({ type: "UPDATE_WIDGET", id: widgetChanges.id, widget: widgetChanges });
  };

  const handleCreateWidget = () => {
    dispatch({ type: "ADD_WIDGET", widget: widgetChanges });
  };

  const handleChange = changes => {
    setWidgetChanges({ ...widgetChanges, ...changes });
  };

  const selectForm = () => {
    switch (widgetChanges.type) {
      case "SingleData":
        return <SingleDataForm onChange={handleChange} widget={widgetChanges} />;

      case "Graph":
        return <GraphForm onChange={handleChange} widget={widgetChanges} />;
      default:
        return "";
    }
  };

  const onSave = () => {
    if (initCreate) {
      handleCreateWidget();
    } else {
      handleUpdateWidget();
    }
    onClose();
  };

  return (
    // SHOULD BE AN ACTUAL FORM
    <div className='widget-form'>
      <div className='content'>
        <div onClick={onClose} className='btn-close' />
        <WidgetTypeSelect onSelectWidgetType={type => handleChange({ type })} selectedType={widgetChanges.type} />
        <div className='form-container'>
          <div className='form-left'>
            <div className='metric-form'>
              <div className='title'>Metric Settings</div>
              {selectForm()}
            </div>
            <TagSelector onChange={handleChange} tags={widgetChanges.tags} />
          </div>
          <div className='form-rigth'>
            <div className='widget-settings-form'>
              <div className='title'>Widget Settings</div>
              <CustomInput
                label='Width'
                value={widgetChanges.width}
                onChange={e => handleChange({ width: parseInt(e.target.value ? e.target.value : 1) })}
                required={true}
              />
              <CustomInput
                label='Height'
                value={widgetChanges.height}
                onChange={e => handleChange({ height: parseInt(e.target.value ? e.target.value : 1) })}
                required={true}
              />
            </div>
            <div className='widget-styling-form'>
              <div className='title'>Color Settings</div>
              <label>Background</label>
              <ColorPicker
                color={widgetChanges.backgroundColor}
                onChange={color => handleChange({ backgroundColor: color })}
              />
              <label>Text</label>
              <ColorPicker color={widgetChanges.textColor} onChange={color => handleChange({ textColor: color })} />
            </div>
          </div>
        </div>
        <div className='buttons-container'>
          <button className='btn-delete' onClick={handleRemoveWidget}>
            DELETE
          </button>
          <button className='btn-cancel' onClick={onClose}>
            CANCEL
          </button>
          <button className='btn-save' onClick={onSave}>
            SAVE
          </button>
        </div>
      </div>
    </div>
  );
};

export default WidgetForm;
