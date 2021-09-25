<template>
  <div class="small">
    <line-chart :chart-data="chartData" :options="options"></line-chart>
  </div>
</template>

<script>
import LineChart from "@/charts/LineChart.js";
export default {
  components: {
    LineChart,
  },
  props: ["chartData", "chartOptions"],
  data() {
    return {
      datacollection: null,
    };
  },
  computed: {
    options() {
      return Object.assign(
        {},
        {
          responsive: true,
          maintainAspectRatio: false,
          aspectRatio: 1,
        },
        this.chartOptions || {}
      );
    },
  },

  mounted() {
    this.fillData();
  },
  methods: {
    fillData() {
      const data1 = Array.from({ length: 12 }).map((el) => this.getRandomInt());
      const data2 = Array.from({ length: 12 }).map((el) => this.getRandomInt());
      const months = [
        "Январь",
        "Февраль",
        "Март",
        "Апрель",
        "Май",
        "Июнь",
        "Июль",
        "Август",
        "Сентябрь",
        "Октябрь",
        "Ноябрь",
        "Декабрь",
      ];
      this.datacollection = {
        labels: months,
        datasets: [
          {
            label: "Data One",
            backgroundColor: "transparent",
            data: data1,
            borderColor: "#4287f5",
          },
          {
            label: "Data One",
            backgroundColor: "transparent",
            data: data2,
            borderColor: "#e81344",
          },
        ],
      };
    },
    getRandomInt() {
      return Math.floor(Math.random() * (50 - 5 + 1)) + 5;
    },
  },
};
</script>

<style scoped>
</style>