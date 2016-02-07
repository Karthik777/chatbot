# Copyright 2015 IBM Corp. All Rights Reserved.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
# https://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

import os
from flask import Flask, jsonify
from flask import abort
from flask import request
from chatterbotapi import *
from io import BytesIO
app = Flask(__name__)
profileImage = []
unrecognizedImage = []

def getMessage(data):
    return json.loads(bytes.decode(data))['message']
@app.route('/eva/chat', methods=['GET'])
def chat_with_eva():
    if request.data is not None:
        message = getMessage(request.data)
        factory = ChatterBotFactory()
        bot2 = factory.create(ChatterBotType.PANDORABOTS, 'b0dafd24ee35a477')
        bot2session = bot2.create_session()
        s = bot2session.think(message);
        return jsonify({'message': s})


@app.route('/Hulk/chat', methods=['GET'])
def eva_chats_with_hulk():
    if request.data is not None:
        message = getMessage(request.data)
        factory = ChatterBotFactory()
        bot1 = factory.create(ChatterBotType.CLEVERBOT)
        bot1session = bot1.create_session()
        s = bot1session.think(message);
        return jsonify({'message': s})

port = os.getenv('PORT', '5000')
if __name__ == "__main__":
    app.run(host='127.0.0.1', port=int(port))

