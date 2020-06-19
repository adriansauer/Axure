import React, { Component } from "react";
import ArrowBackIcon from "@material-ui/icons/ArrowBack";
import api from "../../../Axios/Api.js";
import Notificacion, { notify } from "../../Notificacion";
import Factura from "./Factura.js";
class CrearFactura extends Component {
  constructor(props) {
    super(props);
    this.state = {
      detalles: null,
      productos: null,
      clientes: null,
      condicionNombre: "Contado",
      condicion: 1,
      facturaVisible: false,
      factura: null,
    };
  }
  async componentDidMount() {
    try {
      const clientes = await api.clientes.get();
      const orden = await api.ordenes_venta.getDetalles(this.props.orden.Id);
      const productos = await api.productos.getProductosDeVenta();

      await this.setState({
        productos: productos.data,
      });
      await this.setState({
        clientes: clientes.data,
        detalles: orden.data.ListDetails.map((l) => {
          return {
            Id: l.Id,
            ProductId: l.ProductId,
            Name: this.buscarProducto(l.ProductId).Name,
            Description: this.buscarProducto(l.ProductId).Description,
            Quantity: l.Quantity,
            QuantityPending: l.QuantityPending,
            Cantidad: 0,
          };
        }),
      });
    } catch (error) {
      notify("Error de conexion con la base de datos", "danger");
    }
  }
  ocultar() {
    this.setState({ facturaVisible: false });
  }
  validarCantidades() {
    if (
      this.state.detalles.some((d) => parseInt(d.Cantidad) > d.QuantityPending)
    ) {
      notify("La cantidad ingresada supera la cantidad pendiente", "warning");
      return false;
    } else {
      if (!this.state.detalles.some((d) => parseInt(d.Cantidad) !== 0)) {
        notify("Debe seleccionar al menos un producto", "warning");
        return false;
      }
    }
    return true;
  }

  buscarProducto(id) {
    return this.state.productos.filter((p) => p.Id === id)[0];
  }
  buscarCliente(id) {
    return this.state.clientes.filter((p) => p.Id === id)[0];
  }
  async enviar() {
    if (this.validarCantidades()) {
      const factura = {
        OrderSaleId: this.props.orden.Id,
        EmployeeId: this.props.orden.EmployeeId,
        SaleCondition: "Contado",
        Day: this.props.orden.Day,
        Month: this.props.orden.Month,
        Year: this.props.orden.Year,
        ListItems: this.state.detalles,
      };

      try {
        const request = await api.factura.validate(factura);
        if (request.status === 200) {
          await this.setState({ factura: request.data });
          await this.setState({ facturaVisible: true });
        } else {
          notify("No hay suficiente stock para generar la factura", "warning");
        }
      } catch (error) {
        notify("Error al intentar conectarse con la base de datos", "danger");
      }
    }
  }
  render() {
    const orden = this.props.orden;
  
    if (this.state.facturaVisible) {
      return (
        <Factura
          retroceder={this.ocultar.bind(this)}
          factura={this.state.factura}
          orden={this.props.orden}
        />
      );
    } else {
      return (
        <div className="CrearFactura">
          <Notificacion />
          <div className="CrearFacturaHeader row">
            <div className="col-md-3">
              <ArrowBackIcon
                onClick={() => this.props.retroceder()}
                style={{ height: "50px", width: "50px" }}
              />
            </div>
            <div className="col-md-2">
              <h4>
                {this.state.clientes !== null
                  ? this.buscarCliente(orden.ClientId).Name
                  : ""}
              </h4>
            </div>
            <div className="col-md-1">
              <h4>
                {orden.Day}/{orden.Month}/{orden.Year}
              </h4>
            </div>
            <div className="col-md-3">
              <div className="dropdown">
                <button
                  className="btn btn-secondary btn-sm dropdown-toggle"
                  type="button"
                  id="dropdownMenuButton"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  {this.state.condicionNombre}
                </button>
                <div
                  className="dropdown-menu"
                  aria-labelledby="dropdownMenuButton"
                >
                  <a
                    onClick={() =>
                      this.setState({
                        condicionNombre: "Contado",
                        condicion: 1,
                      })
                    }
                    className="dropdown-item"
                    href="#ingreso"
                  >
                    Contado
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        condicionNombre: "Credito",
                        condicion: 2,
                      })
                    }
                    className="dropdown-item"
                    href="#egreso"
                  >
                    Credito
                  </a>
                </div>
              </div>
            </div>
          </div>
          <div className="row ">
            <div className="col-md-8">
              <table className="table table-hover table">
                <thead className="tableHeader">
                  <tr>
                    <th scope="col">Producto</th>
                    <th scope="col">Cantidad Total</th>
                    <th scope="col">Cantidad pendiente</th>
                    <th scope="col">Cantidad a facturar</th>
                  </tr>
                </thead>
                <tbody className="tableBody">
                  {this.state.detalles !== null
                    ? this.state.detalles.map((p) => (
                        <tr key={p.Id}>
                          <td>
                            {p.Name}
                            {p.Description}
                          </td>
                          <td>{p.Quantity}</td>
                          <td>{p.QuantityPending}</td>
                          <td>
                            <input
                              type="text"
                              className="form-control"
                              placeholder="Cantidad"
                              value={p.Cantidad}
                              onChange={(e) => {
                                const arreglo = this.state.detalles;
                                arreglo[arreglo.indexOf(p)] = {
                                  Name: p.Name,
                                  Id: p.Id,
                                  ProductId: p.ProductId,
                                  Description: p.Description,
                                  Quantity: p.Quantity,
                                  QuantityPending: p.QuantityPending,
                                  Cantidad: e.target.value,
                                };
                                this.setState({
                                  productos: arreglo,
                                });
                              }}
                            />
                          </td>
                        </tr>
                      ))
                    : null}
                </tbody>
              </table>
              <button onClick={() => this.enviar()}>Facturar</button>
            </div>
          </div>
        </div>
      );
    }
  }
}

export default CrearFactura;
