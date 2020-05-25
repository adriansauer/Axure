import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import Notificacion, { notify } from "../../Notificacion.js";
import api from "../../../Axios/Api.js";
/**
 * Propiedades
 * visible: true || false
 * ocultar()
 */

class AgregarCliente extends Component {
  constructor(props) {
    super(props);
    this.state = {
      telefono: "",
      nombre: "",
      ruc: "",
      direccion: "",
      creditomax: "",
    };
  }
  validarCampos() {
    if (
      this.state.telefono === "" ||
      this.state.nombre === "" ||
      this.state.ruc === "" ||
      this.state.direccion === "" ||
      this.state.creditomax === ""
    ) {
      return false;
    } else {
      return true;
    }
  }

  async enviar() {
    if (this.validarCampos()) {
      const cliente = {
        Name: this.state.nombre,
        Address: this.state.direccion,
        RUC: this.state.ruc,
        CreditMaximum:parseInt(this.state.creditomax) ,
      };
      try {
        const request = await api.clientes.create(cliente);
        if (request.status === 200) {
          notify("Cliente creado exitosamente", "success");
          this.setState({
            telefono: "",
            nombre: "",
            ruc: "",
            direccion: "",
            creditomax: "",
          });
          this.props.ocultar();
        } else {
          notify("No se pudo cargar el cliente", "danger");
        }
      } catch (error) {
        console.log(error);
        notify("Error al intentar crear el cliente", "danger");
      }
    } else {
      notify("Rellene todos los campos!", "warning");
    }
  }
  render() {
    return (
      <div>
        <Notificacion />

        <Modal isOpen={this.props.visible} centered>
          <ModalHeader>Agregar cliente</ModalHeader>
          <ModalBody>
            <div className="row">
              <div className="col-md-7">
                {/**NOMBRE DEL CLIENTE*/}
                <input
                  autoComplete="off"
                  type="text"
                  id="nombre"
                  className="form-control"
                  placeholder="Nombre"
                  maxLength="100"
                  onChange={(e)=>this.setState({nombre:e.target.value})}
                />
              </div>
              <div className="col-md-7">
                {/**DIRECCION DEL CLIENTE*/}
                <input
                  autoComplete="off"
                  type="text"
                  id="direccion"
                  className="form-control"
                  placeholder="Direccion"
                  maxLength="200"
                  onChange={(e)=>this.setState({direccion:e.target.value})}
                />
              </div>
              <div className="col-md-7">
                {/**TELEFONO DEL CLIENTE*/}
                <input
                  autoComplete="off"
                  type="text"
                  id="telefono"
                  className="form-control"
                  placeholder="Telefono"
                  maxLength="200"
                  onChange={(e)=>this.setState({telefono:e.target.value})}
                />
              </div>
              <div className="col-md-7">
                {/**RUC DEL CLIENTE*/}
                <input
                  autoComplete="off"
                  type="text"
                  id="ruc"
                  className="form-control"
                  placeholder="RUC"
                  maxLength="20"
                  onChange={(e)=>this.setState({ruc:e.target.value})}
                />
              </div>
              <div className="col-md-7">
                {/**CREDITO MAXIMO DEL CLIENTE*/}
                <input
                  autoComplete="off"
                  type="text"
                  id="creditomax"
                  className="form-control"
                  placeholder="Credito maximo"
                  onChange={(e)=>this.setState({creditomax:e.target.value})}
                />
              </div>
            </div>
          </ModalBody>
          <ModalFooter>
            <button onClick={() => this.enviar()}>Guardar</button>
            <button className="exit" onClick={() => this.props.ocultar()}>
              Cancelar
            </button>
          </ModalFooter>
        </Modal>
      </div>
    );
  }
}
export default AgregarCliente;
