import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import Notificacion, { notify } from "../../Notificacion.js";
import api from "../../../Axios/Api.js";
/**
 * Propiedades
 * visible: true || false
 * ocultar()
 * cliente
 */

class EditarCliente extends Component {
  constructor(props) {
    super(props);
    this.state = {};
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
  validarCampos() {
    if (
      document.getElementById("nombre").value === "" ||
      document.getElementById("direccion").value === "" ||
      document.getElementById("phone") === "" ||
      document.getElementById("ruc").value === "" ||
      document.getElementById("creditomax").value === ""
    ) {
      return false;
    } else {
      return true;
    }
  }
  async enviar() {
    if (this.validarCampos()) {
      try {
        const request = await api.clientes.edit(this.props.cliente.Id, {
          Name: document.getElementById("nombre").value,
          Address: document.getElementById("direccion").value,
          /* Phone: document.getElementById("phone").value,*/
          RUC: document.getElementById("ruc").value,
          CreditMaximum: document.getElementById("creditomax").value,
        });
        if (request.status === 200) {
          notify("Cliente editado exitosamente", "success");
          this.setState({
            telefono: "",
            nombre: "",
            ruc: "",
            direccion: "",
            creditomax: "",
          });
          this.props.ocultar();
        } else {
          notify("No se pudo editar el cliente", "danger");
        }
      } catch (error) {
        console.log(error);
        notify("Error al intentar editar el cliente", "danger");
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
          <ModalHeader>Editar cliente</ModalHeader>
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
                  defaultValue={this.props.cliente.Name}
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
                  defaultValue={this.props.cliente.Address}
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
                  /* defaultValue={this.props.cliente.Phone}*/
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
                  defaultValue={this.props.cliente.RUC}
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
                  defaultValue={this.props.cliente.CreditMaximum}
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
export default EditarCliente;
