import React, { Component } from "react";
import ArrowBackIcon from "@material-ui/icons/ArrowBack";
import api from "../../../Axios/Api.js";
import Notificacion, { notify } from "../../Notificacion";
//import Factura from "./Factura.js";
class CrearFactura extends Component {
  constructor(props) {
    super(props);
    this.state = {
      detalles: null,
      productos: null,
      proveedores: null,
      condicionNombre: "Contado",
      condicion: 1,
      facturaVisible: false,
      factura: null,
      cuotas:1,
      numFactura:"",
    };
  }
  async componentDidMount() {
    try {
      const proveedores = await api.proveedores.get();
      const orden = await api.ordenes_compra.getDetalles(this.props.orden.Id);
      const productos = await api.productos.getProductosDeCompra();

      await this.setState({
        productos: productos.data,
      });
      await this.setState({
        proveedores: proveedores.data,
        detalles: orden.data.ListDetails.map((l) => {
          return {
            Id: l.Id,
            ProductId: l.ProductId,
            ProductName: l.ProductName,
            Quantity: l.Quantity,
            QuantityPending: l.QuantityPending,
            Price: l.Price,
            Cantidad: 1,
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
  buscarProveedor(id) {
    return this.state.proveedores.filter((p) => p.Id === id)[0];
  }
  async enviar() {
    if (this.validarCantidades()) {
      const factura = {
        ProviderId: this.props.orden.ProviderId,
        PurchaseOrderId: this.props.orden.Id,
        InvoiceNumber:"000-001-00"+this.props.orden.Id,
        Day: this.props.orden.Day,
        Month: this.props.orden.Month,
        Year: this.props.orden.Year,
        ListItems: this.state.detalles.filter(p=>parseInt(p.Cantidad)!==0).map((p) => {
          return {
            ProductId: p.ProductId,
            Quantity: p.Cantidad,
          };
        }),
      };

      try {
        const request = await api.factura_compra.create(factura);
        if (request.status === 200) {
          /*await this.setState({ factura: factura });
          await this.setState({ facturaVisible: true });*/
          this.setState({
            detalles: null,
            productos: null,
            proveedores: null,
            condicionNombre: "Contado",
            condicion: 1,
            facturaVisible: false,
            factura: null,
            cuotas:1,
            numFactura:""
          });
          notify("Factura creada exitosamente!", "success");
        } else {
          notify("No se puede generar la factura", "warning");
        }
      } catch (error) {
        notify("Error al intentar conectarse con la base de datos", "danger");
      }
    }
  }

  render() {
    const orden = this.props.orden;
    return (
        <div className="CrearFactura">
          <Notificacion />
          <div className="CrearFacturaHeader row">
            <div className="col-md-1">
              <ArrowBackIcon
                onClick={() => this.props.retroceder()}
                style={{ height: "50px", width: "50px" }}
              />
            </div>
            <div className="col-md-2">
              <h4>
                {this.state.proveedores !== null
                  ? this.buscarProveedor(orden.ProviderId).Name
                  : ""}
              </h4>
            </div>
            <div className="col-md-2">
              <h4>
                {orden.Day}/{orden.Month}/{orden.Year}
              </h4>
            </div>
            <div className="col-md-2">
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
                    href="#contado"
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
                    href="#credito"
                  >
                   
                  </a>
                </div>
              </div>
            </div>
            <div className="col-md-2">
              <label>Cantidad de cuotas(Credito):</label>
            </div>
            <div className="col-md-2">
              
              <div className="dropdown">
                <button
                  className="btn btn-secondary btn-sm dropdown-toggle"
                  type="button"
                  id="dropdownMenuButton"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  {this.state.cuotas}
                </button>
                <div
                  className="dropdown-menu"
                  aria-labelledby="dropdownMenuButton"
                >
                  <a onClick={() =>
                      this.setState({
                        cuotas:1
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                    1
                  </a>
                  <a onClick={() =>
                      this.setState({
                        cuotas:2
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   2
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:3
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   3
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:4
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   4
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:5
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   5
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:6
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   6
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:7
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   7
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:8
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   8
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:9
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   9
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:10
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   10
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:11
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   11
                  </a>
                  <a
                    onClick={() =>
                      this.setState({
                        cuotas:12
                      })
                    }
                    className="dropdown-item"
                    href="#"
                  >
                   12
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
                            {p.ProductName}
                          </td>
                          <td>{p.Quantity}</td>
                          <td>{p.QuantityPending}</td>
                          <td>
                            <input
                              type="number"
                              className="form-control"
                              placeholder="Cantidad"
                              value={p.Cantidad}
                              onChange={(e) => {
                                const arreglo = this.state.detalles;
                                arreglo[arreglo.indexOf(p)] = {
                                  Id: p.Id,
                                  ProductId: p.ProductId,
                                  ProductName: p.ProductName,
                                  Quantity: p.Quantity,
                                  QuantityPending: p.QuantityPending,
                                  Price: p.Price,
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
              {<button className="btn btn-primary" onClick={() => this.enviar()}>Facturar</button>}
            </div>
          </div>
        </div>
      );
    
  }
}

export default CrearFactura;
