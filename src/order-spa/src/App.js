import React, { Component } from "react";
import { ToastContainer } from "react-toastify";
import Joi from "joi-browser";
import orderService from "./services/orderService";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
class App extends Component {
  state = {
    orders: [],
    order: {
      input: ""
    },
    errors: {}
  };

  schema = {
    input: Joi.string().required()
  };

  validate = () => {
    const result = Joi.validate(this.state.order, this.schema, {
      abortEarly: false
    });

    if (!result.error) return null;

    const errors = {};
    for (let item of result.error.details) errors[item.path[0]] = item.message;

    return errors;
  };

  async componentDidMount() {
    const orders = await orderService.getOrders();
    this.setState({ orders });
  }

  handleChange = e => {
    const order = { ...this.state.order };
    order.input = e.currentTarget.value;
    this.setState({ order });
  };

  handleSubmit = async e => {
    e.preventDefault();

    const errors = this.validate();
    this.setState({ errors: errors || {} });
    if (errors) return;

    try {
      const order = this.state.order;
      const result = await orderService.createOrder(order.input);
      console.log(result);

      let newOrders = this.state.orders.slice();
      newOrders.push(result);
      this.setState({ orders: newOrders });
    } catch (ex) {
      console.log(ex.response.data);
      toast.error(ex.response.data);
    }
  };

  render() {
    const orders = this.state.orders;
    return (
      <React.Fragment>
        <ToastContainer />
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
          <div className="container">
            <span className="navbar-brand">Order App</span>
          </div>
        </nav>
        <div className="container" style={{ paddingTop: "15px" }}>
          <h4>Please, order here your meal!</h4>
          <form onSubmit={this.handleSubmit}>
            <div className="form-group">
              <label htmlFor="order">Order</label>
              <input
                type="text"
                className="form-control"
                id="order"
                value={this.state.order.input}
                onChange={this.handleChange}
              />
              {this.state.errors.input && (
                <div className="alert alert-danger">
                  {this.state.errors.input}
                </div>
              )}
              <small id="emailHelp" className="form-text text-muted">
                E.g. morning, 1, 2, 3
              </small>
            </div>
            <button type="submit" className="btn btn-primary">
              Submit
            </button>
          </form>
        </div>
        <div className="container" style={{ paddingTop: "15px" }}>
          <table className="table">
            <thead>
              <tr>
                <th>Input</th>
                <th>Output</th>
              </tr>
            </thead>
            <tbody>
              {orders &&
                orders.map((order, i) => {
                  return (
                    <tr key={order.id}>
                      <td>{order.input}</td>
                      <td>{order.output}</td>
                    </tr>
                  );
                })}
            </tbody>
          </table>
        </div>
      </React.Fragment>
    );
  }
}

export default App;
