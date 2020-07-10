import React from 'react';
import { styled } from '@material-ui/core/styles';
import { Slider, Input, Typography } from '@material-ui/core';

const SliderInputStyle = styled('div')({
	'&>div': {
		display: 'grid',
		gridTemplateColumns: '1fr 5% 30%',
		// margin: '1rem'
	}
})

function SliderInput({ title, value, onChange, min = 0, max = 10, step = 1, marks = false }) {
	return <SliderInputStyle>
		<Typography gutterBottom>{title}</Typography>
		<div>
			<Slider
				value={value}
				onChange={(e, val) => onChange(val)}
				valueLabelDisplay="auto"
				step={step}
				marks={marks}
				min={min}
				max={max}
			/>
			<span />
			<Input
				value={value}
				margin="dense"
				onChange={e => onChange(e.target.value)}
				inputProps={{
					type: 'number',
					step,
					min,
					max
				}}
			></Input>
		</div>
	</SliderInputStyle>
}

export default SliderInput