import { handleActions } from "redux-actions";
import { setModuloSuccess } from "../actions";

export default handleActions(
  {
    [setModuloSuccess]: (state, action) => {
      console.log('asdf');
      return 60;
    },
    
  },
  []
);
