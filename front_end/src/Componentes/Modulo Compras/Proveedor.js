import React, { Component } from "react";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import Api from "../../Axios/Api.js";
import Notificacion, { notify } from "../Notificacion.js";

class Proveedores extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombreSelector: "Todos",
      buscador: "",
      agregarProveedorVisible: false,
      editarProveedorVisible:false,
      proveedor: [],
      proveedorSeleccionado: {
        Id: 0,
        Name: "",
        Address: "",
        RUC: "",
        Phone: "",
        CreditMaximum: "",
      },
    };
  }
  componentDidMount() {
    this.actualizar();
  }
  async actualizar() {
    try {
      const proveedores = await Api.clientes.get();
      this.setState({ proveedores: proveedores.data });
    } catch (error) {
      notify("No se pudo conectar a la base de datos", "danger");
    }
  }
  async ocultarModales() {
    this.setState({ agregarProveedorVisible: false,editarProveedorVisible:false });
    await this.actualizar();
  }
  seleccionarProveedor(prov) {
    this.setState({ proveedorSeleccionado: prov });
  }
  async eliminarProveedor(prov) {
    await this.seleccionarProveedor(prov);
    try {
      const request = await Api.clientes.delete(
        this.state.proveedorSeleccionado.Id
      );
      if (request.status === 200) {
        notify("Proveedor eliminado con exito", "success");
        await this.actualizar();
      } else {
        notify("Error al intentar eliminar el Proveedor", "danger");
      }
    } catch (error) {
      notify("Error al intentar eliminar el Proveedor", "danger");
    }
  }
 async  editarProveedor(prov){
    await this.seleccionarProveedor(prov);
    this.setState({editarProveedorVisible:true});
  }
  render() {
    return (
      <div className="Container">
        <Notificacion />
        <div className="row ">
          <div className="col-md-6 mr-auto pl-0">
            {/**Un buscador de productos */}
            <div className="col-sm-12 pl-0">
              <div className="input-group mb-3">
                <input
                  type="text"
                  className="form-control buscador"
                  aria-label="Busqueda"
                  placeholder="Busqueda..."
                  value={this.state.buscador}
                  onChange={(e) => {
                    this.setState({ buscador: e.target.value });
                  }}
                />
              </div>
            </div>
          </div>
          <button
            className="btn btn-primary"
            onClick={() => this.setState({ agregarProveedorVisible: true })}
          >
            Agregar Proveedor
          </button>
        </div>

        <div className="row">
          <table className="table table-hover table" style={{ marginTop: 50 }}>
            <thead className="tableHeader">
              <tr>
                <th scope="col">Nombre</th>
                <th scope="col">Direccion</th>
                <th scope="col">Ruc</th>
                <th scope="col">Acciones</th>
              </tr>
            </thead>
            <tbody className="tableBody">
              {this.state.proveedor.length !== 0
                ? this.state.proveedor
                    .filter(
                      (p) =>
                        p.Name.toLowerCase().indexOf(
                          this.state.buscador.toLowerCase()
                        ) !== -1
                    )
                    .map((c) => (
                      <tr key={c.Id}>
                        <td>{c.Name}</td>
                        <td>{c.Address}</td>
                        <td>{c.RUC}</td>
                        <td>
                          <EditIcon onClick={()=>this.editarProveedor(c)} />
                          <DeleteIcon onClick={() => this.eliminarProveedor(c)} />
                        </td>
                      </tr>
                    ))
                : null}
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}

export default Proveedores;
