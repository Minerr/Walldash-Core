const getAliases = () => {
  //console.log("GET: Aliases");
  return ["turnover", "basketSize"];
};

const getAllByAlias = alias => {
  //console.log("GET: All by alias: ", alias);
  switch (alias.toLowerCase()) {
    case "turnover":
      return turnOverData;
    case "basketsize":
      return basketSizeData;
    case "cpu performance":
      return CpuPerformanceData;
    default:
      return "";
  }
};

export default {
  getAliases,
  getAllByAlias
};

const turnOverData = {
  data: [
    {
      id: "1cUQp9WjwTTdehcfu8n2",
      number: 80,
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "Turnover",
      accountId: "WWDm6rcpEAuEO8ePabKr"
    },
    {
      id: "M0aVk2RmsXlTok3nvS4y",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "Turnover",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 150
    },
    {
      id: "UdNPFVASrPa6VLYjFEeo",
      number: 250,
      timestamp: "2019-12-08T11:34:56.012Z",
      alias: "Turnover",
      accountId: "WWDm6rcpEAuEO8ePabKr"
    },
    {
      id: "XJ46JV8cFHmnryhTSwIR",
      alias: "Turnover",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 170,
      timestamp: "2019-12-08T22:50:00.000Z"
    },
    {
      id: "YSZsqdNAV8MpQCZ2yR8B",
      number: 320,
      timestamp: "2019-12-08T00:58:43.000Z",
      alias: "Turnover",
      accountId: "WWDm6rcpEAuEO8ePabKr"
    },
    {
      id: "fK1Pb9fGnBKkwn7PhfKi",
      timestamp: "2019-12-08T00:58:43.000Z",
      alias: "Turnover",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 518
    },
    {
      id: "hl652xvLmwIb8NnNS6hZ",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "Turnover",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 432
    },
    {
      id: "hl652xvLmwIb8NnNS6hZ",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "Turnover",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 320
    },
    {
      id: "hl652xvLmwIb8NnNS6hZ",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "Turnover",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 610
    }
  ]
};

const basketSizeData = {
  data: [
    {
      id: "1cUQp9WjwTTdehcfu8n2",
      number: 7329,
      timestamp: "2019-12-08T11:34:00.000Z",
      alias: "BasketSize",
      accountId: "WWDm6rcpEAuEO8ePabKr"
    },
    {
      id: "M0aVk2RmsXlTok3nvS4y",
      timestamp: "2019-12-08T00:58:43.000Z",
      alias: "BasketSize",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 6420
    },
    {
      id: "UdNPFVASrPa6VLYjFEeo",
      number: 6802,
      timestamp: "2019-12-08T11:34:56.012Z",
      alias: "BasketSize",
      accountId: "WWDm6rcpEAuEO8ePabKr"
    },
    {
      id: "XJ46JV8cFHmnryhTSwIR",
      alias: "BasketSize",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 7124,
      timestamp: "2019-12-08T22:50:00.000Z"
    },
    {
      id: "YSZsqdNAV8MpQCZ2yR8B",
      number: 7629,
      timestamp: "2019-12-08T00:58:43.000Z",
      alias: "BasketSize",
      accountId: "WWDm6rcpEAuEO8ePabKr"
    },
    {
      id: "fK1Pb9fGnBKkwn7PhfKi",
      timestamp: "2019-12-08T00:58:43.000Z",
      alias: "BasketSize",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 8100
    },
    {
      id: "hl652xvLmwIb8NnNS6hZ",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "BasketSize",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 9249
    },
    {
      id: "hl652xvLmwIb8NnNS6hZ",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "BasketSize",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 11230
    },
    {
      id: "hl652xvLmwIb8NnNS6hZ",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "BasketSize",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 15920
    }
  ]
};

const CpuPerformanceData = {
  data: [
    {
      id: "1cUQp9WjwTTdehcfu8n2",
      number: 10,
      timestamp: "2019-12-08T11:34:00.000Z",
      alias: "CPU Performance",
      accountId: "WWDm6rcpEAuEO8ePabKr"
    },
    {
      id: "M0aVk2RmsXlTok3nvS4y",
      timestamp: "2019-12-08T00:58:43.000Z",
      alias: "CPU Performance",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 25
    },
    {
      id: "UdNPFVASrPa6VLYjFEeo",
      number: 23,
      timestamp: "2019-12-08T11:34:56.012Z",
      alias: "CPU Performance",
      accountId: "WWDm6rcpEAuEO8ePabKr"
    },
    {
      id: "XJ46JV8cFHmnryhTSwIR",
      alias: "CPU Performance",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 75,
      timestamp: "2019-12-08T22:50:00.000Z"
    },
    {
      id: "YSZsqdNAV8MpQCZ2yR8B",
      number: 81,
      timestamp: "2019-12-08T00:58:43.000Z",
      alias: "CPU Performance",
      accountId: "WWDm6rcpEAuEO8ePabKr"
    },
    {
      id: "fK1Pb9fGnBKkwn7PhfKi",
      timestamp: "2019-12-08T00:58:43.000Z",
      alias: "CPU Performance",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 32
    },
    {
      id: "hl652xvLmwIb8NnNS6hZ",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "CPU Performance",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 41
    },
    {
      id: "hl652xvLmwIb8NnNS6hZ",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "CPU Performance",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 81
    },
    {
      id: "hl652xvLmwIb8NnNS6hZ",
      timestamp: "2019-12-08T00:00:00.000Z",
      alias: "CPU Performance",
      accountId: "WWDm6rcpEAuEO8ePabKr",
      number: 45
    }
  ]
};
