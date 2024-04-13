<script setup lang="ts">
import { ref, onMounted } from 'vue'
import WelcomeItem from './WelcomeItem.vue'
import DocumentationIcon from './icons/IconDocumentation.vue'
import WeatherIcon from './icons/IconWeather.vue'

interface WeatherForecast {
  date: string
  temperatureC: number
  temperatureF: number
  summary: string
}

type Forecasts = WeatherForecast[];

const forecasts = ref([]);
const loading = ref(true);
const error = ref(null);

onMounted(() => {
/*
*     fetch(`${import.meta.env.VITE_WEATHER_API_HTTPS || import.meta.env.VITE_WEATHER_API_HTTP}/weatherforecast`)
      .then(response => response.json())
      .then(data => {
        this.forecasts = data
      })
      .catch(error => {
        this.error = error
      })
      .finally(() => (this.loading = false))
  }

* */
})


</script>

<template>
  <WelcomeItem>
    <template #icon>
      <DocumentationIcon />
    </template>
    <template #heading>Documentation</template>

    Vue’s
    <a href="https://vuejs.org/" target="_blank" rel="noopener">official documentation</a>
    provides you with all information you need to get started.
  </WelcomeItem>
  <WelcomeItem>
    <template #icon>
      <WeatherIcon />
    </template>
    <template #heading>Weather</template>
    <table>
      <thead>
      <tr>
        <th>Date</th>
        <th>Temp. (C)</th>
        <th>Temp. (F)</th>
        <th>Summary</th>
      </tr>
      </thead>
      <tbody>
<!--      <tr v-for="forecast in (forecasts as Forecasts)">-->
<!--        <td>{{ forecast.date }}</td>-->
<!--        <td>{{ forecast.temperatureC }}</td>-->
<!--        <td>{{ forecast.temperatureF }}</td>-->
<!--        <td>{{ forecast.summary }}</td>-->
<!--      </tr>-->
      </tbody>
    </table>
    
  </WelcomeItem>


</template>

<style>
table {
  border: none;
  border-collapse: collapse;
}

th {
  font-size: x-large;
  font-weight: bold;
  border-bottom: solid .2rem hsla(160, 100%, 37%, 1);
}

th,
td {
  padding: 1rem;
}

td {
  text-align: center;
  font-size: large;
}

tr:nth-child(even) {
  background-color: var(--vt-c-black-soft);
}
</style>