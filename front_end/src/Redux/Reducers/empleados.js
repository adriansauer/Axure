import { handleActions } from "redux-actions";
import { getEmpleadosSuccess} from "../actions";

export default handleActions(
  {
    [getEmpleadosSuccess]: (state, action) => {
      return action.payload;
    },
   
  },
  []
);
