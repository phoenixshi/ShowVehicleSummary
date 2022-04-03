export default function fetchModels(){
  //Call api to get all models
  return (dispatch) => {
    fetch('https://localhost:44387/vehicle-checks/makes/Lotus')
      .then(res => res.json())
      .then(vehicles => {
        dispatch({
          type: "success",
          models: vehicles.models,
          loading: false,
        })
      })
      .catch(console.log);
  }
}

export function fetchModel(model){
  if(model === "") {
    //If "all" is selected clear the value of select model and years
    return (dispatch) => {
      dispatch({
        type: "yearsuccess",
        selectModel: model,
        years: [],
        loading: false,
      })
      }
    } else {
      //Get years for selected model
      return (dispatch) => {
        fetch('https://localhost:44387/vehicle-checks/makes/Lotus/model/'+model)
          .then(res => res.json())
          .then(result => {
            dispatch({
              type: "yearsuccess",
              selectModel: model,
              years: result,
              loading: false,
            })
          })
          .catch(console.log);     
      }
    }

}