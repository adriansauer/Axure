import { handleActions } from "redux-actions";
import { getMateriasPrimas_TerminadosSuccess } from "../actions";

export default handleActions(
  {
    [getMateriasPrimas_TerminadosSuccess]: (state, action) => {
      return action.payload;
    },
  },
  []
);
