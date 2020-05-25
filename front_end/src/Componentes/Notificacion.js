import React, { Component } from "react";
import { Alert } from "reactstrap";
import ee from "event-emitter";

const emitter = new ee();
export const notify = (msg,color) => {
  emitter.emit("notification", msg,color);
};
class Notifications extends Component {
  _isMounted = false;
  constructor(props) {
    super(props);
    
    this.state = {
      top: -120,
      msg: "",
      color:""
    };
    this.timeout = null;
    emitter.on("notification", (msg,color) => {
        this.onShow(msg,color);
    });
  }
 
  onShow = (msg,color) => {
    this._isMounted = true;
    if (this.timeout) {
      clearTimeout(this.timeout);
      this.setState({ top: -100 }, () => {
        this.timeout = setTimeout(() => {
          this.showNotification(msg,color);
        }, );
      });
    } else {
      this.showNotification(msg,color);
    }
    this._isMounted = false;
  };
  showNotification = (msg,color) => {
    this.setState(
      {
        msg:msg,
        color:color,
        top: 16,
      },
      () => {
        this.timeout = setTimeout(() => {
          this.setState({
            
            top: -120,
            
          });
        },3000);
      }
    );
  };

  render() {
    return (
        <Alert color={this.state.color}
        style={{
           
            
            top:this.state.top+'px',
            right: "50%",
            zIndex: "999",
            transition: "top 0.5s ease",
            position: "absolute",
          }}>
            {this.state.msg}
        </Alert>
    );
}
}

export default Notifications;
