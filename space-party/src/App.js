import React from 'react';
import { styled, createMuiTheme, ThemeProvider } from '@material-ui/core/styles';
import Settings from './Settings';
import Sketch from './Sketch';
import { useRefState } from './utility';

const theme = createMuiTheme({
	palette: {
		type: "dark",
		text: {
			primary: '#ffffff',
			// secondary: 'rgb(0,255,0)',
			// 	hint: 'rgb(255,0,255)'

		},
		// divider: 'rgb(255,0,255)'


	}
})


const AppStyle = styled('div')({
	color: "white",
	wordWrap: 'break-word',
	boxSizing: "border-box",
	MozBoxSizing: "border-box",
	WebkitBoxSizing: "border-box",
	fontFamily: '"Montserrat", sans-serif',
	background: 'linear-gradient(45deg, rgb(0,0,0) 10%, rgb(0,0,64) 50%)',
	width: '100vw',
	minHeight: '100vh',
	display: 'grid',
	gridTemplateColumns: '1fr min(80rem,90%) 1fr',
	// gridTemplateColumns: '1fr 90% 1fr',
	gridTemplateRows: '3rem 1fr 2rem',
	gridTemplateAreas: `
	"header header header"
	". content ."
	"footer footer footer"
	`,
})

const HeaderFooterStyle = styled('div')({
	textAlign: "center",
	display: 'grid',
	gridTemplateColumns: '1fr 1fr 1fr',
	// gridTemplateRows: '1fr 20% 1fr',
	gridTemplateAreas: `
	". . ."
	". centered ."
	". . ."
	`,
	"&> *": {
		gridArea: 'centered'
	},
	"& h1": {
		margin: 0
	},
	// color: 'white',
	backgroundColor: 'rgba(0,0,0,0.5)'
})

const HeaderStyle = styled(HeaderFooterStyle)({
	gridArea: 'header',

})

const FooterStyle = styled(HeaderFooterStyle)({
	gridArea: 'footer',
	// verticalAlign: 'middle'
})

const ContentStyle = styled('div')({
	gridArea: 'content',
	// padding: "1rem",
	// color: 'white',
	background: 'rgba(0,0,0,0)',
	display: 'grid',
	gridTemplateColumns: 'min(20rem, 20%) 1fr',
	// gridTemplateRows: 'fit-content(100%) 1fr'
})


function App() {

	const [settings, setSettings, settingsRef] = useRefState({
		date: new Date(),
		daysPerSecond: 1,
		distanceScaleIterations: 5,
		distanceScaleMin: 0.7,
		distanceScaleMax: 0.7,
	})
	return <ThemeProvider theme={theme}>
		<AppStyle>
			<HeaderStyle>
				<h1>Space Party</h1>
			</HeaderStyle>
			<ContentStyle>
				<Settings settings={settings} setSettings={setSettings} />
				<Sketch settingsRef={settingsRef} setSettings={setSettings} />
			</ContentStyle>
			<FooterStyle>
				<div>made with ♥ by chantey</div>
			</FooterStyle>
		</AppStyle>
	</ThemeProvider>

}

export default App;
