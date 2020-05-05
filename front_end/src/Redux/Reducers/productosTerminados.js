import { handleActions } from "redux-actions";
import { getProductosTerminadosSuccess } from "../actions";

export default handleActions(
  {
    [getProductosTerminadosSuccess]: (state, action) => {
      return action.payload;
    },
  },
  []
);
