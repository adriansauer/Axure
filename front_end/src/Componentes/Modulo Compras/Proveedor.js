import React, { Component } from "react";
import Api from "../../Axios/Api.js";
import Notificacion, { notify } from "../Notificacion.js";
import AgregarProveedor from "./Modales/AgregarProveedor.js";

class Proveedor extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombreSelector: "Todos",
      buscador: "",
      proveedores: [],
      proveedorSeleccionado: {
        Id: 0,
        Name: "",
        Address: "",
        RUC: "",
        Phone: "",
      },
      agregarProveedorVisible:false,
    };
  }
  componentDidMount() {
    this.actualizar();
  }
  async actualizar() {
    try {
      const proveedores = await Api.proveedores.get();
      this.setState({ proveedores: proveedores.data });
    } catch (error) {
      notify("No se pudo conectar a la base de datos", "danger");
    }
  }
  async ocultar() {
    this.setState({ agregarProveedorVisible: false,editarPRoveeVisible:false });
    await this.actualizar();
  }
  /*seleccionarCliente(cliente) {
    this.setState({ clienteSeleccionado: cliente });
  }
  async eliminarCliente(cliente) {
    await this.seleccionarCliente(cliente);
    try {
      const request = await Api.clientes.delete(
        this.state.clienteSeleccionado.Id
      );
      if (request.status === 200) {
        notify("Proveedor eliminado con exito", "success");
        await this.actualizar();
      } else {
        notify("Error al intentar eliminar el proveedor", "danger");
      }
    } catch (error) {
      notify("Error al intentar eliminar el proveedor", "danger");
    }
  }
 async  editarCliente(cliente){
    await this.seleccionarProveedor(cliente);
    this.setState({editarClienteVisible:true});
  }*/
  render() {
    return (
      <div className="Container">
        <Notificacion />
        <AgregarProveedor
        visible={this.state.agregarProveedorVisible}
        ocultar={this.ocultar.bind(this)}
        />
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
            onClick={()=>this.setState({agregarProveedorVisible:true})}
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
                {/*<th scope="col">Acciones</th>*/}
              </tr>
            </thead>
            <tbody className="tableBody">
              {this.state.proveedores.length !== 0
                ? this.state.proveedores
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
                        {/*<td>
                          <EditIcon onClick={()=>this.editarCliente(c)} />
                          <DeleteIcon onClick={() => this.eliminarCliente(c)} />
                        </td>*/}
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

export default Proveedor;
