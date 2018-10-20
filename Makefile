SOURCE_NAME = LMCN_v1.80
SOURCE_PACKAGE_NAME = $(SOURCE_NAME).apk
RELEASE_NAME = $(SOURCE_PACKAGE_NAME)
SOURCE_DIR = $(SOURCE_NAME)/src
BACKUP_DIR = $(SOURCE_NAME)/backup
RELEASE_DIR = $(SOURCE_NAME)/dest
DECRYPT_DLL_SRC = $(SOURCE_DIR)/assets/bin/Data/Managed/Assembly-CSharp.dll
DECRYPT_DLL_BACKUP = $(BACKUP_DIR)/assets/bin/Data/Managed/Assembly-CSharp.dll
DECRYPT_DLL_DEST = $(SOURCE_DIR)/assets/bin/Data/Managed/Assembly-CSharp.dll
CERTIFICATE_PATH = my-release-key.jks
CERTIFICATE_ALIAS = my-alias
CERTIFICATE_PASS = gamesoeasy
ANDROID_SDK_PATH = ~/Library/Android/sdk/build-tools/25.0.2
JAVA_PACKAGE_NAME = com.igg.android.lordsmobile_cn

all: encode sign-apk install

init: decode backup decrypt

clean:
	find . -name '.DS_Store' -print0 | xargs -0 rm -rf
	rm -rf $(RELEASE_DIR)

dep:
	brew install apktool

genkey:
	keytool -genkey -v -keystore $(CERTIFICATE_PATH) -keyalg RSA -keysize 2048 -validity 10000 -alias $(CERTIFICATE_ALIAS)

backup:
	rm -rf $(BACKUP_DIR)
	cp -R $(SOURCE_DIR) $(BACKUP_DIR)

decode:
	apktool d $(SOURCE_PACKAGE_NAME) -o $(SOURCE_DIR) -f

decrypt:
	python crypt.py $(DECRYPT_DLL_BACKUP) $(DECRYPT_DLL_DEST)

encrypt:
	python crypt.py -e $(DECRYPT_DLL_BACKUP) $(DECRYPT_DLL_DEST)

restore:
	cp -R $(DECRYPT_DLL_BACKUP) $(DECRYPT_DLL_SRC)
	make decrypt

encode:
	make clean
	make encrypt
	apktool b $(SOURCE_DIR) -o $(RELEASE_DIR)/$(RELEASE_NAME)
	make decrypt

sign-apk:
	$(ANDROID_SDK_PATH)/apksigner sign --ks $(CERTIFICATE_PATH) --ks-key-alias $(CERTIFICATE_ALIAS) --ks-pass pass:gamesoeasy --key-pass pass:gamesoeasy $(RELEASE_DIR)/$(RELEASE_NAME)

verify-apk:
	$(ANDROID_SDK_PATH)/apksigner verify $(RELEASE_DIR)/$(RELEASE_NAME)

install:
	adb install -r $(RELEASE_DIR)/$(RELEASE_NAME)

watch:
	fswatch -o -e '.*' -Ei '.*[^_]+\.go$$' . | xargs -I {} make build docker_run

log:
	docker-compose logs --follow api

docker_run:
	docker-compose build && docker-compose up -d
