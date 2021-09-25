<template>
  <div class="wrapper">
    <Loader :loading="loading"></Loader>
    <div class="content">
      <div class="dashboard">
        <div class="main-filter">
          <v-row class="ma-0" align="center">
            <filter-select
              outlined
              class="ma-2 filter"
              label="Фильтр"
              :items="filtersList"
              :returnObject="true"
              itemText="name"
              hide-details
              multiple
              v-model="selectedFilters"
            ></filter-select>
            <v-select
              outlined
              class="ma-2 filter"
              label="Параметр"
              :items="parametersList"
              hide-details
              v-model="selectedParameter"
            >
            </v-select>
            <v-btn
              class="btn ma-2"
              outlined
              color="primary"
              @click="setChartData"
              >ПРИМЕНИТЬ</v-btn
            >
            <v-btn class="btn drop-filters ma-2" outlined @click="drop"
              >СБРОСИТЬ</v-btn
            >
          </v-row>
        </div>
        <v-expansion-panels flat v-model="expand">
          <v-expansion-panel class="ex-panel">
            <v-expansion-panel-header> Фильтры </v-expansion-panel-header>
            <v-expansion-panel-content>
              <div class="filters">
                <v-row class="ma-0">
                  <template v-for="filter in selectedFilters">
                    <filter-select
                      v-if="filter.type === 'SELECT'"
                      :key="filter.id"
                      outlined
                      class="ma-2 filter"
                      :label="filter.name"
                      :items="filter.options"
                      hide-details
                      multiple
                      @input="updateFilterValues"
                    ></filter-select>
                  </template>
                </v-row>
              </div>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
        <div class="charts">
          <FluidityWithParams
            :chartData="chartData"
            :chartOptions="chartOptions"
          ></FluidityWithParams>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import api from "../api/filters";
import FilterSelect from "../components/FilterSelect.vue";
import { API_TIMEOUT, months } from "../vars";
import { getRandomInt, sleep } from "../utils";
import FluidityWithParams from "../components/charts/FluidityWithParams.vue";
import Loader from "../components/Loader.vue";
export default {
  components: { FluidityWithParams, Loader, FilterSelect },
  data: () => ({
    loading: true,
    filtersList: [],
    filterValues: {},
    selected: [],
    selectedFilters: [],
    selectedParameter: null,
    parametersList: [],
    chartData: [],
    expand: null,
    filtersChanged: true,
  }),
  computed: {
    /* chartData() {}, */
    chartOptions() {
      return {
        scales: {
          yAxes: [
            {
              ticks: {
                callback: function (value) {
                  return value.toLocaleString("de-DE", { style: "percent" });
                },
              },
            },
          ],
        },
      };
    },
  },
  watch: {
    selectedFilters() {
      this.expand = 0;
    },
    selectedParameter() {
      this.filtersChanged = true;
    },
  },
  methods: {
    updateFilterValues(id, value) {
      this.filterValues[id] = value;
      this.filtersChanged = true;
    },
    async initData() {
      this.loading = true;
      this.filtersList = await api.getFiltersList();
      this.parametersList = await api.getParametersList();
      this.setChartData();
      this.expand = null;
      this.loading = false;
    },
    async setChartData() {
      this.loading = true;
      this.expand = null;
      await sleep(API_TIMEOUT);
      const data1 = Array.from({ length: 12 }).map((el) => Math.random());
      const data2 = Array.from({ length: 12 }).map((el) => Math.random());
      const dataset1 = {
        label: "текучесть",
        backgroundColor: "transparent",
        data: data1,
        borderColor: "#4287f5",
      };
      const dataset2 = this.selectedParameter
        ? {
            label: this.selectedParameter,
            backgroundColor: "transparent",
            data: data2,
            borderColor: "#e81344",
          }
        : null;
      const chartData = {
        labels: months,
        datasets: [dataset1, dataset2].filter((el) => el),
      };
      if (this.filtersChanged) {
        this.chartData = chartData;
      }
      this.filtersChanged = false;
      this.loading = false;
    },
    async drop() {
      this.selectedFilters = [];
      this.filterValues = {};
      this.filtersChanged = true;
      this.selectedParameter = null;
      this.initData();
    },
  },

  async created() {
    await this.initData();
  },
};
</script>
<style scoped>
.filter {
  max-width: 240px;
  width: 230px;
}
.dashboard {
  display: flex;
  flex-direction: column;
}
.btn {
  height: 56px !important;
  width: 230px;
}
.drop-filters {
  border-color: gray;
  color: b;
}
.ex-panel {
  padding: 0 !important;
}
</style>