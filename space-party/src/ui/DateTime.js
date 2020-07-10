import React from 'react';
import { styled } from '@material-ui/core/styles';

import DateMomentUtils from '@date-io/moment';
import moment from 'moment';
import {
	MuiPickersUtilsProvider,
	KeyboardDatePicker,
	KeyboardTimePicker
} from '@material-ui/pickers';
import 'moment/locale/en-au';

moment.locale("en-au")
// const [locale, setLocale] = React.useState("en-au")


function DateTime({ date, setDate }) {
	return <MuiPickersUtilsProvider libInstance={moment} utils={DateMomentUtils} locale={"en-au"}>
		<KeyboardDatePicker
			variant="inline"
			inputVariant="outlined"
			format="DD/MM/yyyy"
			label="Date"
			value={date}
			minDate={new Date("0001-01-01")}
			maxDate={new Date("2100-01-01")}
			onChange={setDate}
			autoOk
		/>
		<KeyboardTimePicker
			variant="inline"
			inputVariant="outlined"
			format="h:mm A"
			label="Time"
			// ampm={false}
			value={date}
			onChange={setDate}
			autoOk
		/>
	</MuiPickersUtilsProvider>

}

export default DateTime