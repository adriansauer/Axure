import React, { Component } from "react";
import ".././styleMProductos.css";
import api from "../../../Axios/Api.js";
import Notificacion, { notify } from "../../Notificacion.js";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import DeleteIcon from "@material-ui/icons/Delete";

/**Props
 * visible
 * ocultar()
 */
class AgregarProducto extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombretxt: "",
      descripciontxt: "",
      costotxt: "",
      codigoBarratxt: "",
      cantidadMintxt: "",
      tipoProducto: 1,
      buscador: "",
      componentesSeleccionados: [],
      listarMateriaPrimaVisible: false,
      productos: null,
      categoria: "Monitor",
      categoriaId: 1,
    };
  }
  async componentDidMount() {
    const p = await api.productos.getProductosDeCompra();
    this.setState({ productos: p.data });
  }
  filtroDeLetras(texto){
    if(texto==""){
      return true;
    }else if(!isNaN(texto[texto.length-1])){
      return true;
    }else{
      return false;
    }
  }
  seleccionarComponente(p) {
    this.setState({
      ...this.state,
      componentesSeleccionados: this.state.componentesSeleccionados.concat({
        Name: p.Name,
        Id: p.Id,
        Description: p.Description,
        Barcode: p.Barcode,
        Cantidad: "1",
      }),
    });
    this.setState({ buscador: "" });
  }
  verificarCampos() {
    if (
      this.state.tipoProducto === 3 &&
      this.state.componentesSeleccionados.length === 0
    ) {
      notify("Seleccione al menos un componente", "warning");
      return false;
    }

    if (
      this.state.nombretxt !== "" &&
      this.state.costotxt !== "" &&
      this.state.codigoBarratxt !== "" &&
      this.state.descripciontxt !== ""
    ) {
      return true;
    }
    return false;
  }
  async enviarProducto() {
    const paquete = {
      Name: this.state.nombretxt,
      ProductTypeId: this.state.tipoProducto,
      Description: this.state.descripciontxt,
      Cost: this.state.costotxt,
      TaxId: 3,
      QuantityMin:
        this.state.costotxt === "" ? 0 : parseInt(this.state.cantidadMintxt),
      Barcode: this.state.codigoBarratxt,
      ProductCategoryId: this.state.categoriaId,
      ListComponents: this.state.componentesSeleccionados.map((p) => {
        return {
          ProductComponentId: p.Id,
          Quantity: parseInt(p.Cantidad),
        };
      }),
    };

    try {
      const request = await api.productos.create(paquete);

      notify("Producto creado exitosamente!", "success");
      this.setState({
        nombretxt: "",
        descripciontxt: "",
        costotxt: "",
        codigoBarratxt: "",
        cantidadMintxt: "",
        tipoProducto: 1,
        componentesSeleccionados: [],
      });

      notify("Producto creado exitosamente", "success");
    } catch (error) {
      notify("No se pudo crear el producto!", "danger");
    }
  }
  toggleShow(param) {
    if (document.getElementById(param) !== null) {
      document.getElementById(param).classList.toggle("show");
    }
  }
  handleSubmit = (event) => {
    event.preventDefault();
    if (this.verificarCampos()) {
      this.enviarProducto();
    } else {
      notify("Rellene todos los campos obligatorios", "warning");
    }
  };
  delete(id) {
    this.setState({
      componentesSeleccionados: this.state.componentesSeleccionados.filter(
        (producto) => producto.Id !== id
      ),
    });
  }
  render() {
    if (this.state.tipoProducto === 3) {
      return (
        <div>
          <Modal isOpen={this.props.visible} className="modal-xl">
            <Notificacion />
            <ModalHeader>
              <label className="m-auto title-label">Agregar Producto</label>
              <label style={{ color: "red" }}> *</label>
              <lable> Campos obligatorios</lable>
            </ModalHeader>
            <ModalBody>
              <div className="row">
                <div className="col-md-6">
                  <form onSubmit={this.handleSubmit}>
                    <div className="form-group row mb-2">
                      <label htmlFor="" className="">
                        Nombre del Producto
                        <input
                          type="text"
                          className="form-control"
                          style={(this.state.nombretxt!=="")?{borderColor:"green"}:{borderColor:"red"}}
                          placeholder="Nombre del Producto"
                          value={this.state.nombretxt}
                          onChange={(e) => {
                            this.setState({ nombretxt: e.target.value });
                          }}
                        />
                      </label>
                    </div>

                    <div className="form-group row mb-3">
                      <label htmlFor="" className="">
                        Descripcion del Producto
                      </label>
                      <textarea
                        className="form-control"
                        style={(this.state.descripciontxt!=="")?{borderColor:"green"}:{borderColor:"red"}}
                        placeholder="Descripcion del producto"
                        value={this.state.descripciontxt}
                        onChange={(e) => {
                          this.setState({ descripciontxt: e.target.value });
                        }}
                        rows="3"
                      ></textarea>
                      <div className="dropdown">
                        <button
                          className="btn btn-secondary btn-sm dropdown-toggle"
                          type="button"
                          id="dropdownMenuButton"
                          data-toggle="dropdown"
                          aria-haspopup="true"
                          aria-expanded="false"
                        >
                          {this.state.categoria}
                        </button>
                        <div
                          className="dropdown-menu"
                          aria-labelledby="dropdownMenuButton"
                        >
                          <a
                            onClick={() =>
                              this.setState({
                                categoria: "Monitores",
                                categoriaId: 1,
                              })
                            }
                            className="dropdown-item"
                            href="#ingreso"
                          >
                            Monitor
                          </a>
                          <a
                            onClick={() =>
                              this.setState({
                                categoria: "Teclados",
                              })
                            }
                            className="dropdown-item"
                            href="#egreso"
                          >
                            Teclados
                          </a>
                          <a
                            onClick={() =>
                              this.setState({
                                categoria: "Mouses",
                                categoriaId: 3,
                              })
                            }
                            className="dropdown-item"
                            href="#egreso"
                          >
                            Mouses
                          </a>
                          <a
                            onClick={() =>
                              this.setState({
                                categoria: "Placas",
                                categoriaId: 4,
                              })
                            }
                            className="dropdown-item"
                            href="#egreso"
                          >
                            Placas
                          </a>
                          <a
                            onClick={() =>
                              this.setState({
                                categoria: "Procesadores",
                                categoriaId: 5,
                              })
                            }
                            className="dropdown-item"
                            href="#egreso"
                          >
                            Procesadores
                          </a>
                          <a
                            onClick={() =>
                              this.setState({
                                categoria: "Computadoras de mesa",
                                categoriaId: 6,
                              })
                            }
                            className="dropdown-item"
                            href="#egreso"
                          >
                            Computadores de mesa
                          </a>
                        </div>
                      </div>
                    </div>
                    <div className="dropdown-divider"></div>
                    <div className="form-group row mb-2">
                      <label htmlFor="" className="">
                        Costo{" "}
                      </label>
                      <input
                        type="text"
                        className="form-control"
                        placeholder="Costo"
                        value={this.state.costotxt}
                        style={(this.state.costotxt!=="")?{borderColor:"green"}:{borderColor:"red"}}
                        onChange={(e) => {
                          this.setState({ costotxt:(this.filtroDeLetras(e.target.value))? e.target.value:this.state.costotxt });                        
                        }}
                      />
                    </div>
                    <div className="form-group row mb-2">
                      <label htmlFor="" className="">
                        Cantidad Minima
                      </label>
                      <input
                        type="text"
                        className="form-control"
                        placeholder="Cantidad Minima"
                        value={this.state.cantidadMintxt}
                        onChange={(e) => {
                          this.setState({ cantidadMintxt:(this.filtroDeLetras(e.target.value))? e.target.value:this.state.cantidadMintxt });                    
                            }}
                      />
                    </div>
                    <div className="form-group row mb-3">
                      <label htmlFor="" className="">
                        Codigo de Barra
                      </label>
                      <input
                        type="text"
                        className="form-control"
                        style={(this.state.codigoBarratxt!=="")?{borderColor:"green"}:{borderColor:"red"}}
                        placeholder="Codigo de barra"
                        value={this.state.codigoBarratxt}
                        onChange={(e) => {
                          this.setState({ codigoBarratxt:(this.filtroDeLetras(e.target.value))? e.target.value:this.state.codigoBarratxt });
                        }}
                      />
                    </div>
                    <div className="dropdown-divider"></div>
                    <div className="form-group row">
                      <label>Tipo de Producto</label>
                      <div className="form-group check-list mx-auto">
                        <div className="form-check form-check-inline">
                          <input
                            type="radio"
                            className="mr-1"
                            value="1"
                            checked={this.state.tipoProducto === 2}
                            onChange={(e) => {
                              this.setState({ tipoProducto: 2 });
                            }}
                          />
                          <label
                            className="form-check-label mr-2"
                            htmlFor="inlineRadio1"
                          >
                            Materia Prima
                          </label>
                        </div>
                        <div className="form-check form-check-inline">
                          <input
                            type="radio"
                            className="mr-1"
                            value="2"
                            checked={this.state.tipoProducto === 3}
                            onChange={(e) => {
                              this.setState({ tipoProducto: 3 });
                            }}
                          />
                          <label
                            className="form-check-label mr-2"
                            htmlFor="inlineRadio2"
                          >
                            Producto Terminado
                          </label>
                        </div>
                        <div className="form-check form-check-inline">
                          <input
                            type="radio"
                            className="mr-1"
                            value="3"
                            checked={this.state.tipoProducto === 1}
                            onChange={(e) => {
                              this.setState({ tipoProducto: 1 });
                            }}
                          />
                          <label
                            className="form-check-label"
                            htmlFor="inlineRadio3"
                          >
                            Ambos
                          </label>
                        </div>
                      </div>
                    </div>
                    <div className="dropdown-divider"></div>
                    <div className="form-group row mt-3">
                      <button
                        type="submit"
                        className="btn btn-primary ml-auto"
                        value="Crear Producto"
                      >
                        Crear Producto
                      </button>
                      <button
                        className="btn btn-primary ml-auto"
                        onClick={() => this.props.ocultar()}
                      >
                        Cancelar
                      </button>
                    </div>
                  </form>
                </div>
                <div
                  className="col-md-6"
                  style={{
                    overflowY: "scroll",
                    overflowX: "hidden",
                    height: "300px",
                  }}
                >
                  <table className="table table-hover table">
                    <thead className="tableHeader">
                      <tr>
                        <th scope="col">#</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Descripcion</th>
                        <th scope="col">Codigo de barra</th>
                        <th scope="col">Cantidad</th>
                        <th scope="col">Acciones</th>
                      </tr>
                    </thead>
                    <tbody className="tableBody">
                      {this.state.componentesSeleccionados.map((p) => (
                        <tr key={p.Id}>
                          <td>{p.Id}</td>
                          <td>{p.Name}</td>
                          <td>{p.Description}</td>
                          <td>{p.Barcode}</td>

                          {/**obtiene la cantidad de este componente que se utilizara para el producto terminado */}
                          <td>
                            <input
                              type="text"
                              className="form-control"
                              placeholder="Cantidad"
                              value={p.Cantidad}
                              onChange={(e) => {
                                const arreglo = this.state
                                  .componentesSeleccionados;
                                arreglo[arreglo.indexOf(p)] = {
                                  Name: p.Name,
                                  Id: p.Id,
                                  Description: p.Description,
                                  Barcode: p.Barcode,
                                  Cantidad: e.target.value,
                                };
                                this.setState({
                                  componentesSeleccionados: arreglo,
                                });
                              }}
                            />
                          </td>
                          {/**Boton para sacar de la lista el producto */}
                          <td>
                            <DeleteIcon onClick={() => this.delete(p.Id)} />
                          </td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                  <div className="row">
                    <div className="col-md-6">
                      <div className="dropup">
                        <input
                          type="text"
                          className="form-control form-control-sm buscador"
                          id="id1"
                          placeholder="Añadir componente"
                          required="required"
                          onChange={(e) => {
                            this.setState({ buscador: e.target.value });
                            this.toggleShow("dropdown-buscador");
                          }}
                          value={this.state.buscador}
                        />
                        <div className="dropdown-menu" id="dropdown-buscador">
                          {this.state.buscador !== ""
                            ? this.state.productos
                                .filter(
                                  (producto) =>
                                    producto.Name.toLowerCase().indexOf(
                                      this.state.buscador.toLowerCase()
                                    ) !== -1
                                )
                                .filter(
                                  (producto) =>
                                    this.state.componentesSeleccionados.find(
                                      (e) => e.Id === producto.Id
                                    ) === undefined
                                )
                                .map((p) => (
                                  <tr
                                    key={p.Id}
                                    onClick={() =>
                                      this.seleccionarComponente(p)
                                    }
                                  >
                                    <td>{p.Id}</td>
                                    <td>{p.Name}</td>
                                    <td>{p.Description}</td>
                                    <td>{p.Cost}</td>
                                    <td>{p.Barcode}</td>
                                  </tr>
                                ))
                            : null}
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>{" "}
            </ModalBody>
            <ModalFooter></ModalFooter>
          </Modal>
        </div>
      );
    } else {
      return (
        <div>
          <Modal isOpen={this.props.visible}>
            <Notificacion />
            <ModalHeader>
              <label className="m-auto title-label">Agregar Producto</label>
              <label style={{ color: "red" }}> *</label>
              <lable> Campos obligatorios</lable>
            </ModalHeader>
            <ModalBody>
              {" "}
              <form onSubmit={this.handleSubmit}>
                <div className="form-group row mb-2">
                  <label htmlFor="" className="">
                    Nombre del Producto
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    placeholder="Nombre del Producto"
                    value={this.state.nombretxt}
                    style={
                      this.state.nombretxt !== ""
                        ? { borderColor: "green" }
                        : { borderColor: "red" }
                    }
                    onChange={(e) => {
                      this.setState({ nombretxt: e.target.value });
                    }}
                  />
                </div>
                <div className="form-group row mb-3">
                  <label htmlFor="" className="">
                    Descripcion del Producto
                  </label>
                  <textarea
                    className="form-control"
                    placeholder="Descripcion del producto"
                    style={
                      this.state.descripciontxt !== ""
                        ? { borderColor: "green" }
                        : { borderColor: "red" }
                    }
                    value={this.state.descripciontxt}
                    onChange={(e) => {
                      this.setState({ descripciontxt: e.target.value });
                    }}
                    rows="3"
                  ></textarea>
                </div>
                <div className="dropdown">
                  <button
                    className="btn btn-secondary btn-sm dropdown-toggle"
                    type="button"
                    id="dropdownMenuButton"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                  >
                    {this.state.categoria}
                  </button>
                  <div
                    className="dropdown-menu"
                    aria-labelledby="dropdownMenuButton"
                  >
                    <a
                      onClick={() =>
                        this.setState({
                          categoria: "Monitores",
                          categoriaId: 1,
                        })
                      }
                      className="dropdown-item"
                      href="#ingreso"
                    >
                      Monitor
                    </a>
                    <a
                      onClick={() =>
                        this.setState({
                          categoria: "Teclados",
                        })
                      }
                      className="dropdown-item"
                      href="#egreso"
                    >
                      Teclados
                    </a>
                    <a
                      onClick={() =>
                        this.setState({
                          categoria: "Mouses",
                          categoriaId: 3,
                        })
                      }
                      className="dropdown-item"
                      href="#egreso"
                    >
                      Mouses
                    </a>
                    <a
                      onClick={() =>
                        this.setState({
                          categoria: "Placas",
                          categoriaId: 4,
                        })
                      }
                      className="dropdown-item"
                      href="#egreso"
                    >
                      Placas
                    </a>
                    <a
                      onClick={() =>
                        this.setState({
                          categoria: "Procesadores",
                          categoriaId: 5,
                        })
                      }
                      className="dropdown-item"
                      href="#egreso"
                    >
                      Procesadores
                    </a>
                    <a
                      onClick={() =>
                        this.setState({
                          categoria: "Computadoras de mesa",
                          categoriaId: 6,
                        })
                      }
                      className="dropdown-item"
                      href="#egreso"
                    >
                      Computadores de mesa
                    </a>
                  </div>
                </div>
                <div className="dropdown-divider"></div>
                <div className="form-group row mb-2">
                  <label htmlFor="" className="">
                    Costo{" "}
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    placeholder="Costo"
                    style={
                      this.state.costotxt !== ""
                        ? { borderColor: "green" }
                        : { borderColor: "red" }
                    }
                    value={this.state.costotxt}
                    onChange={(e) => {
                      this.setState({ costotxt:(this.filtroDeLetras(e.target.value))? e.target.value:this.state.costotxt });                    }}
                  />
                </div>
                <div className="form-group row mb-2">
                  <label htmlFor="" className="">
                    Cantidad Minima
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    placeholder="Cantidad Minima"
                    value={this.state.cantidadMintxt}
                    onChange={(e) => {  
                      this.setState({ cantidadMintxt:(this.filtroDeLetras(e.target.value))? e.target.value:this.state.cantidadMintxt });
                    }}
                  />
                </div>
                <div className="form-group row mb-3">
                  <label htmlFor="" className="">
                    Codigo de Barra
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    style={(this.state.codigoBarratxt!=="")?{borderColor:"green"}:{borderColor:"red"}}
                    placeholder="Codigo de barra"
                    value={this.state.codigoBarratxt}
                    onChange={(e) => {
                      this.setState({ codigoBarratxt:(this.filtroDeLetras(e.target.value))? e.target.value:this.state.codigoBarratxt });
                    }}
                  />
                </div>
                <div className="dropdown-divider"></div>
                <div className="form-group row">
                  <label>Tipo de Producto</label>
                  <div className="form-group check-list mx-auto">
                    <div className="form-check form-check-inline">
                      <input
                        type="radio"
                        className="mr-1"
                        value="1"
                        checked={this.state.tipoProducto === 2}
                        onChange={(e) => {
                          this.setState({ tipoProducto: 2 });
                        }}
                      />
                      <label
                        className="form-check-label mr-2"
                        htmlFor="inlineRadio1"
                      >
                        Materia Prima
                      </label>
                    </div>
                    <div className="form-check form-check-inline">
                      <input
                        type="radio"
                        className="mr-1"
                        value="2"
                        checked={this.state.tipoProducto === 3}
                        onChange={(e) => {
                          this.setState({ tipoProducto: 3 });
                        }}
                      />
                      <label
                        className="form-check-label mr-2"
                        htmlFor="inlineRadio2"
                      >
                        Producto Terminado
                      </label>
                    </div>
                    <div className="form-check form-check-inline">
                      <input
                        type="radio"
                        className="mr-1"
                        value="3"
                        checked={this.state.tipoProducto === 1}
                        onChange={(e) => {
                          this.setState({ tipoProducto: 1 });
                        }}
                      />
                      <label
                        className="form-check-label"
                        htmlFor="inlineRadio3"
                      >
                        Ambos
                      </label>
                    </div>
                  </div>
                </div>
                <div className="dropdown-divider"></div>
                <div className="form-group row mt-3">
                  <button
                    type="submit"
                    className="btn btn-primary ml-auto"
                    value="Crear Producto"
                  >
                    Crear Producto
                  </button>
                </div>
              </form>
            </ModalBody>
            <ModalFooter>
              <button
                className="btn btn-primary ml-auto"
                onClick={() => this.props.ocultar()}
              >
                Cancelar
              </button>
            </ModalFooter>
          </Modal>
        </div>
      );
    }
  }
}

export default AgregarProducto;
