import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import Notificacion, { notify } from "../../Notificacion.js";
import api from "../../../Axios/Api.js";
/**
 * Propiedades
 * visible: true || false
 * ocultar()
 */

class AgregarProveedor extends Component {
  constructor(props) {
    super(props);
    this.state = {
      telefono: "",
      nombre: "",
      ruc: "",
      direccion: "",
      categorias: null,
    };
  }
  async componentDidMount() {
    try {
      const categorias = await api.categoria.get();
      this.setState({ categorias: categorias.data });
    } catch (error) {
      notify("Error al intentar conectar con la base de datos", "danger");
    }
  }
  validarCampos() {
    if (
      this.state.telefono === "" ||
      this.state.nombre === "" ||
      this.state.ruc === "" ||
      this.state.direccion === "" ||
      this.state.creditomax === "" ||
      this.state.categorias
        .filter((c) => document.getElementById(c.Id).checked)
        .map((c) => c.Id).length === 0
    ) {
      return false;
    } else {
      return true;
    }
  }

  async enviar() {
    if (this.validarCampos) {
      const categoriasSeleccionadas = this.state.categorias
        .filter((c) => document.getElementById(c.Id).checked)
        .map((c) => {
          return {
            Category: {
              Id: c.Id,
            },
          };
        });
      const proveedor = {
        Name: this.state.nombre,
        Address: this.state.direccion,
        RUC: this.state.ruc,
        Phone: this.state.telefono,
        ListCategories: categoriasSeleccionadas,
      };
      console.log(proveedor);
      try {
        const request = await api.proveedor.create(proveedor);
        if (request.status === 200) {
          notify("Proveedor creado exitosamente", "success");
          this.setState({
            telefono: "",
            nombre: "",
            ruc: "",
            direccion: "",
            creditomax: "",
          });
          this.props.ocultar();
        } else {
          notify("No se pudo cargar el proveedor", "danger");
        }
      } catch (error) {
        notify("Error al intentar crear el proveedor", "danger");
      }
    } else {
      notify(
        "Rellene todos los campos o seleccione al menos una categoria!",
        "warning"
      );
    }
  }
  render() {
    return (
      <div>
        <Notificacion />

        <Modal isOpen={this.props.visible} centered>
          <ModalHeader>Agregar proveedor</ModalHeader>
          <ModalBody>
            <div className="row">
              <div className="col-md-5">
                <div className="col-md-12">
                  {/**NOMBRE DEL PROVEEDOR*/}
                  <input
                    autoComplete="off"
                    type="text"
                    id="nombre"
                    className="form-control"
                    placeholder="Nombre"
                    maxLength="100"
                    onChange={(e) => this.setState({ nombre: e.target.value })}
                  />
                </div>
                <div className="col-md-12">
                  {/**DIRECCION DEL PROVEEDOR*/}
                  <input
                    autoComplete="off"
                    type="text"
                    id="direccion"
                    className="form-control"
                    placeholder="Direccion"
                    maxLength="200"
                    onChange={(e) =>
                      this.setState({ direccion: e.target.value })
                    }
                  />
                </div>
                <div className="col-md-12">
                  {/**TELEFONO DEL PROVEEDOR*/}
                  <input
                    autoComplete="off"
                    type="text"
                    id="telefono"
                    className="form-control"
                    placeholder="Telefono"
                    maxLength="200"
                    onChange={(e) =>
                      this.setState({ telefono: e.target.value })
                    }
                  />
                </div>
                <div className="col-md-12">
                  {/**RUC DEL PROVEEDOR*/}
                  <input
                    autoComplete="off"
                    type="text"
                    id="ruc"
                    className="form-control"
                    placeholder="RUC"
                    maxLength="20"
                    onChange={(e) => this.setState({ ruc: e.target.value })}
                  />
                </div>
               
              </div>
              <div
                className="col-md-7"
                style={{
                  overflowY: "scroll",
                  overflowX: "hidden",
                  height: "200px",
                }}
              >
                <table className="table table-hover table">
                  <thead className="tableHeader">
                    <tr>
                      <th scope="col">Categoria</th>
                      <th scope="col">Seleccionar</th>
                    </tr>
                  </thead>
                  <tbody className="tableBody">
                    {this.state.categorias !== null
                      ? this.state.categorias.map((c) => (
                          <tr key={c.Id}>
                            <td>{c.Description}</td>
                            <td>
                              <input type="checkbox" id={c.Id} />
                            </td>
                          </tr>
                        ))
                      : null}
                  </tbody>
                </table>
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
export default AgregarProveedor;
