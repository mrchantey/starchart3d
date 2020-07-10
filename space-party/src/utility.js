import React from 'react';

function useRefState(initialValue) {
	const [state, setState] = React.useState(initialValue)
	const stateRef = React.useRef(state)
	React.useEffect(() => { stateRef.current = state }, [state])
	return [state, setState, stateRef] //DIFFERENT FROM CHANTEY.ORG (state,stateRef,setState)
}


export {
	useRefState
}
