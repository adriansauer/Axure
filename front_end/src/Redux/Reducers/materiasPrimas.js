import { handleActions } from "redux-actions";
import { getMateriasPrimasSuccess } from "../actions";

export default handleActions(
  {
    [getMateriasPrimasSuccess]: (state, action) => {
      return action.payload;
    },
  },
  []
);
