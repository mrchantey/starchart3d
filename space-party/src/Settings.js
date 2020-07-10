import React from 'react';
import { Typography } from '@material-ui/core';
import { styled } from '@material-ui/core/styles';
import DateTime from './ui/DateTime';
import SliderInput from './ui/SliderInput';

const SettingsStyle = styled('div')({
	margin: '1rem',
	display: 'grid',
	gridTemplateColumns: '1fr',
	// gridTemplateRows: 'repeat(1fr,15)',
	'&> *': {
	}
})

const Settings = ({ settings, setSettings }) => {

	return <SettingsStyle>
		<Typography variant="h4">Settings</Typography>
		<DateTime
			date={settings.date}
			setDate={date => setSettings(prev => ({ ...prev, date }))}
		/>
		<SliderInput
			title="Days Per Second"
			value={settings.daysPerSecond}
			onChange={val => setSettings(prev => ({ ...prev, daysPerSecond: val }))}
			min={0}
			max={100}
			step={0.01}
		/>
		<SliderInput
			title="Distance Scale Iterations"
			value={settings.distanceScaleIterations}
			onChange={val => setSettings(prev => ({ ...prev, distanceScaleIterations: val }))}
			min={0}
			max={32}
			step={1}
		/>
		<SliderInput
			title="Distance Scale Min"
			value={settings.distanceScaleMin}
			onChange={val => setSettings(prev => ({ ...prev, distanceScaleMin: val }))}
			min={0}
			max={1}
			step={0.01}
		/>
		<SliderInput
			title="Distance Scale Max"
			value={settings.distanceScaleMax}
			onChange={val => setSettings(prev => ({ ...prev, distanceScaleMax: val }))}
			min={0}
			max={1}
			step={0.01}
		/>
	</SettingsStyle>
}


export default Settings

// moment.defaultFormat()
/*
to install date stuff
npm i date-fns npm i npm i @date-io/moment@1.x  @material-ui/pickers
*/
