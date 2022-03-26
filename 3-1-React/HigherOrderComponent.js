`A component that takes a component as an argument, 
and returns a updated component is called HOC(higher-order component)`

import React from 'react';

const HigherOrderComponent = (inputComponent) => {
  return class outputComponent extends Component {
    render() {
      const newProps = {
        title: "New Header",
        footer: false,
        showFeatureX: false,
        showFeatureY: true,
      };

      return <inputComponent {...this.props} {...newProps} />;
    }
  };
};
