<template>
  <div class="wrapper">
    <div class="content">
      <div class="dashboard" ref="dashboard">
        <h2 class="mt-12 mb-5">Уровень текучести сотрудников</h2>
        <div class="charts">
          <FluidityWithParams
            :chartData="chartData"
            :chartOptions="chartOptions"
          ></FluidityWithParams>
        </div>
        <div class="cards mt-6">
          <v-row class="ma-0">
            <v-card
              class="mx-auto"
              width="322"
              outlined
              v-for="card in cards"
              :key="card.id"
            >
              <v-list-item three-line>
                <v-list-item-content>
                  <v-list-item-title class="text-h5 mb-1">
                    {{ card.value }}
                  </v-list-item-title>
                  <v-list-item-subtitle>{{
                    card.description
                  }}</v-list-item-subtitle>
                </v-list-item-content>
              </v-list-item>

              <v-card-actions>
                <v-btn color="primary" text @click="$router.push('/analytics')">
                  Подробнее
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-row>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { months } from "../vars";
import FluidityWithParams from "../components/charts/FluidityWithParams.vue";
export default {
  name: "Home",
  data: () => ({
    cards: [
      { id: 1, description: "Месяц с наибольшей текучестью", value: "Январь" },
      { id: 1, description: "Месяц с наименьшей текучестью", value: "Июнь" },
      {
        id: 1,
        description: "Должность с наибольшей текучестью",
        value: "Кладовщик",
      },
    ],
  }),
  components: { FluidityWithParams },
  computed: {
    chartData() {
      const data1 = Array.from({ length: 12 }).map((el) => Math.random());
      const chartData = {
        labels: months,
        datasets: [
          {
            label: "Текучесть",
            backgroundColor: "transparent",
            data: data1,
            borderColor: "#4287f5",
          },
        ],
      };
      return chartData;
    },
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
        legend: {
          display: false,
        },
      };
    },
  },
  mounted() {
    const dashboard = this.$refs.dashboard;
    const chart = dashboard.querySelector("#line-chart");
    chart.style.width = "1016px";
    chart.style.height = "300px";
    console.log("chartData", this.chartData);
  },
};
</script>
<style scoped>
</style>