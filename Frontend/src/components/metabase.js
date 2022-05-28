import React, {useEffect, useRef, useState} from "react";
import IframeResizer from 'iframe-resizer-react'

const MetabaseAppEmbed = ({url = "", personalKey = ""}) => {
    return (
        <IframeResizer
            src={url + personalKey}
            style={{width: '1px', minWidth: '100%'}}
            frameBorder="0"
        />
    );
};

export default MetabaseAppEmbed;