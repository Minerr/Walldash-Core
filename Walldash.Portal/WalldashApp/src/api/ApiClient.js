import axios from "axios";

var bearerToken = "";

const accountToken = "FFDB19C4-E99E-4503-8F0A-A5EAD55DA56A";
const url = "http://api.mfabricius.dk/api";

const getBearerToken = () => {
  return new Promise(resolve => {
    const settings = {
      url: "https://walldash.eu.auth0.com/oauth/token",
      method: "POST",
      headers: {
        "content-type": "application/json"
      },
      data:
        '{"client_id":"PA0gYNYYTe5rPN82BWQ42gNRJUgs0jNR","client_secret":"LPjk9FpPBwgPpOMMI3yzag-ec2gfX6YskG9joleT2yOuIcFw3cDSLJGmMnTjg0Af","audience":"walldash.dk/api/","grant_type":"client_credentials"}'
    };
    axios(settings).then(response => {
      resolve((bearerToken = `Bearer ${response.data.access_token}`));
    });
  });
};

// ---------- WIDGETS ----------

const getWidgets = id => {
  return new Promise(resolve => {
    const settings = {
      url: `${url}/Widget/GetByDashboardId/${id}`,
      method: "GET",
      headers: {
        "content-type": "application/json",
        Authorization: bearerToken,
        "Account-Token": accountToken
      }
    };

    axios(settings).then(response => {
      resolve(response.data);
    });
  });
};

const updateWidget = (id, widget) => {
  return new Promise(resolve => {
    const settings = {
      url: `${url}/Widget/${id}`,
      method: "PUT",
      headers: {
        "content-type": "application/json",
        Authorization: bearerToken,
        "Account-Token": accountToken
      },
      data: widget
    };

    axios(settings).then(response => {
      resolve(response.data);
    });
  });
};

const createWidget = widget => {
  return new Promise(resolve => {
    const settings = {
      url: `${url}/Widget`,
      method: "POST",
      headers: {
        "content-type": "application/json",
        Authorization: bearerToken,
        "Account-Token": accountToken
      },
      data: widget
    };

    axios(settings).then(response => {
      resolve(response.data);
    });
  });
};

const deleteWidget = id => {
  return new Promise(resolve => {
    const settings = {
      url: `${url}/Widget/${id}`,
      method: "DELETE",
      headers: {
        "content-type": "application/json",
        Authorization: bearerToken,
        "Account-Token": accountToken
      }
    };

    axios(settings).then(response => {
      resolve(response.data);
    });
  });
};

// ---------- METRICS ----------

const getMetricAliases = () => {
  return new Promise(resolve => {
    const settings = {
      url: `${url}/Metric/GetAliases`,
      method: "GET",
      headers: {
        "content-type": "application/json",
        Authorization: bearerToken,
        "Account-Token": accountToken
      }
    };

    axios(settings).then(response => {
      resolve(response.data);
    });
  });
};

// ---------- DASHBOARDS ----------

const getDashboards = () => {
  return new Promise(resolve => {
    const settings = {
      url: `${url}/Dashboard`,
      method: "GET",
      headers: {
        "content-type": "application/json",
        Authorization: bearerToken,
        "Account-Token": accountToken
      }
    };

    axios(settings).then(response => {
      resolve(response.data);
    });
  });
};

const createDashboard = alias => {
  return new Promise(resolve => {
    const settings = {
      url: `${url}/Dashboard`,
      method: "POST",
      headers: {
        "content-type": "application/json",
        Authorization: bearerToken,
        "Account-Token": accountToken
      },
      data: {
        alias
      }
    };

    axios(settings).then(response => {
      resolve(response.data);
    });
  });
};

const deleteDashboard = id => {
  return new Promise(resolve => {
    const settings = {
      url: `${url}/Dashboard/${id}`,
      method: "DELETE",
      headers: {
        "content-type": "application/json",
        Authorization: bearerToken,
        "Account-Token": accountToken
      }
    };

    axios(settings).then(response => {
      resolve(response.data);
    });
  });
};

const updateDashboard = (id, alias) => {
  return new Promise(resolve => {
    const settings = {
      url: `${url}/Dashboard/${id}`,
      method: "PUT",
      headers: {
        "content-type": "application/json",
        Authorization: bearerToken,
        "Account-Token": accountToken
      },
      data: {
        id,
        alias
      }
    };

    axios(settings).then(response => {
      resolve(response.data);
    });
  });
};

export default {
  getBearerToken,
  getMetricAliases,
  getDashboards,
  createDashboard,
  deleteDashboard,
  updateDashboard,
  getWidgets,
  updateWidget,
  createWidget,
  deleteWidget
};
