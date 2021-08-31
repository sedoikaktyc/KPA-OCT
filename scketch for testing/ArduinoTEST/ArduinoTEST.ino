
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО КНОПОК!
#define BUTTNUM 1

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО КНОПОК!
const byte buttIn[] = {2};
bool buttLog[] = {true};

String str = "";
int i;


int led = 9;


void setup() {
  Serial.begin(115200); // Инициализация порта для работы с ПК
  GetName();
  GetStartPositions();

}

void loop() {
  // put your main code here, to run repeatedly:


  ////                                                                            ////
  //        РАБОТА КНОПОК                                                           //
  ////                                                                            ////

  for (int i = 0; i < BUTTNUM; i++) { // Опрос кнопок
    if (digitalRead(buttIn[i]) == LOW && buttLog[i] == false) {
      delay(250);
      Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
      buttLog[i] = true;
    }
    else if (digitalRead(buttIn[i]) == HIGH && buttLog[i] == true) {
      delay(250);
      Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
      buttLog[i] = false;
    }
  }

  ////////////////////////////////////////////////////////////////////////////////////
  ////////                                                                    ////////
  ////                                                                            ////
  //        СВЯЗЬ С ПК                                                              //
  ////                                                                            ////
  ////////                                                                    ////////
  ////////////////////////////////////////////////////////////////////////////////////

  if (Serial.available() > 0) { // Проверка, что есть данные от ПК
    str = Serial.readStringUntil('\n');
    //Serial.print("USER: ");
    //Serial.println(str);



    ///запрос имени кпа
    if (str == "GetName") {
      GetName();
    }

    ///запрос положение кпа
    if (str == "GetStartPosition") {
      GetStartPositions();
    }

    if (str == "on") {

      digitalWrite(led, HIGH);

    }
    if (str == "off") {
      digitalWrite(led, LOW);
    }


    ////                                                                            ////
    //        СВЯЗЬ С ПК ДЛЯ РАЗЪЕМОВ                                                 //
    ////                                                                            ////


    ////                                                                            ////
    //        СВЯЗЬ С ПК ДЛЯ КНОПОК                                                   //
    ////                                                                            ////

    if (str.substring(0, 4).equals("butt")) { // Принудительный опрос кнопки
      i = str.substring(4, 7).toInt();
      if (digitalRead(buttIn[i]) == HIGH) {
        /*  Serial.print("b");
          Serial.print(i);
          Serial.println(" off"); */
      }
      else if (digitalRead(buttIn[i]) == LOW) {
        /* Serial.print("b");
          Serial.print(i);
          Serial.println(" on"); */
      }
    }

  }
}

void GetName() {

  Serial.println("kpa9");

}

void GetStartPositions() {

  Serial.println("complite");

  pinMode(led, OUTPUT);
  ////                                                                            ////
  //        НАСТРОЙКИ КНОПОК                                                        //
  ////                                                                            ////

  for (int i = 0; i < BUTTNUM; i++) {
    pinMode(buttIn[i], INPUT); // Настройка пина на вход
    digitalWrite(buttIn[i], HIGH); // Подтяжка пина к питанию
  }

  for (int i = 0; i < BUTTNUM; i++) { // Опрос кнопок
    if (digitalRead(buttIn[i]) == HIGH) {
      Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
    }
    else if (digitalRead(buttIn[i]) == LOW) {
      Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
      buttLog[i] = true;
    }

  }


  Serial.println("stop");

}
