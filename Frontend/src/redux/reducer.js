const defaultState = {
  loading: true,
  models: [],
  selectModel: "",
  years: []
}

export default function reducer(state = defaultState, action) {
   switch (action.type) {
    case "loading":
      return {
        ...state,
        loading: true,
      };
    case "success":
      //get all models successfully
      return {
        ...state,
        loading: false,
        models: action.models
      };
    case "yearsuccess":
      //get years for selected model successfully
      return {
        ...state,
        loading: false,
        years: action.years,
        selectModel: action.selectModel
      };
    default:
      return state;
  }
}