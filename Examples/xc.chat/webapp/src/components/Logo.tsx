import * as React from "react";
import * as SVGIcon from "grommet/components/SVGIcon";

const CLASS_ROOT = "ferret-logo";

enum LogoSize {
  medium,
  large
}

interface LogoProps {
  busy: boolean;
  colorIndex: string;
  size: LogoSize;
}

class Logo extends React.Component<any, any> {
  public static defaultProps: LogoProps = {
    busy: false,
    colorIndex: "brand",
    size: LogoSize.medium
  };

  render() {
    const { busy, className, colorIndex, size, ...props } = this.props;
    let classes = [CLASS_ROOT];
    if (busy) {
      classes.push(`${CLASS_ROOT}--busy`);
    }
    if (className) {
      classes.push(className);
    }
    return (
      <SVGIcon {...props} className={classes.join("")}
        colorIndex={colorIndex} size={LogoSize[size]} viewBox="0 0 120 120" version="1.1"
        type="logo" a11yTitle="Ferret Logo" >
        <g fill="none">
          <rect stroke="none" x="0" y="0" width="120" height="120"></rect>
          <g className="paths" strokeWidth="4">
            <path d="M54,96 L54,106 L14,106 L14,66 L24,66"></path>
            <path d="M24,36 L84,36 L84,96 L24,96 L24,36"></path>
            <path d="M34,36 L34,18 L102,18 L102,86 L84,86"></path>
            <rect x="34" y="66" width="20" height="20"></rect>
          </g>
        </g>
      </SVGIcon>
    );
  }

}

export default Logo;