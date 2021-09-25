import { sleep } from "../utils"
import { API_TIMEOUT } from '../vars'
const api = {
    getFiltersList: async function () {
        await sleep(API_TIMEOUT)
        return [
            {
                id: "position",
                name: 'Должность',
                type: 'SELECT',
                options: [
                    'слесарь', 'токарь', 'экономист',
                ]
            },
            {
                id: "city",
                name: 'Города',
                type: 'SELECT',
                options: [
                    'Москва', 'Курск', 'Белгород',
                ]
            },
            {
                id: "gender",
                name: 'Пол',
                type: 'SELECT',
                options: [
                    'мужской', 'женский',
                ]
            },
            {
                id: "familyStatus",
                name: 'Семейное положение',
                type: 'SELECT',
                options: [
                    'холост', 'женат/замужем', 'разведен',
                ]
            },
            {
                id: "mentor",
                name: 'Наличие наставника',
                type: 'SELECT',
                options: [
                    'да', 'нет',
                ],
            }
            /*   {
                  id: "minAge",
                  name: 'Минимальный возраст',
                  type: 'NUMBER_INPUT',
              },
              {
                  id: "maxAge",
                  name: 'Максимальный возраст',
                  type: 'NUMBER_INPUT',
              } */
        ]

    },
    getParametersList: async function () {
        await sleep(API_TIMEOUT)
        return [
            'возраст', 'опыт работы', 'количество детей', 'зарплата'
        ]

    },

}



export default api

