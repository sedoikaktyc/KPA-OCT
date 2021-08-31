
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО КНОПОК!
#define BUTTNUM 2

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО КНОПОК!
const byte buttIn[] = {8,9};
bool buttLog[] = {false,false};

String str = "";
int i;

int led = 2;


int sensorPin = A1;    // Порт к которому подключен потенциометр
int sensorValue = 0;  // Переменная для хранения показаний
int sensorValueOld = 0;


void setup() {
  Serial.begin(115200); // Инициализация порта для работы с ПК

  pinMode(8, INPUT_PULLUP);
  pinMode(9, INPUT_PULLUP);
  
  GetName();
  GetStartPositions();
}

void loop() {

  ///пт///
  sensorValue = analogRead(sensorPin);
  if ((sensorValue > sensorValueOld + 50) || (sensorValue < sensorValueOld - 50)) {
    Serial.print("p");
    Serial.print("#");
    Serial.print(0);
    Serial.print("#");
    if (sensorValue > 950) {
      sensorValue = 1000;
    }
    Serial.println(sensorValue);
    sensorValueOld = sensorValue ;
  }

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
      Serial.println("1.00");
      buttLog[i] = true;
    }
    else if (digitalRead(buttIn[i]) == HIGH && buttLog[i] == true) {
      delay(250);
      Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0.00");
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






  }
}

void GetName() {

  Serial.println("kpa10");

}

void GetStartPositions() {

  Serial.println("complite");

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
      Serial.println("0.00");
    }
    else if (digitalRead(buttIn[i]) == LOW) {
      Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1.00");
      buttLog[i] = true;
    }

  }

  pinMode(led, OUTPUT);




  sensorValue = analogRead(sensorPin);
  Serial.print("p");
  Serial.print("#");
  Serial.print(0);
  Serial.print("#");
  if (sensorValue > 950) {
    sensorValue = 1000;
  }
  Serial.println(sensorValue);
  sensorValueOld = sensorValue ;

  Serial.println("stop");

}
