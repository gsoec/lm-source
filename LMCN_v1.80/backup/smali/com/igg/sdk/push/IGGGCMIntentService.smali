.class public Lcom/igg/sdk/push/IGGGCMIntentService;
.super Landroid/app/IntentService;
.source "IGGGCMIntentService.java"


# static fields
.field protected static final TAG:Ljava/lang/String; = "GCMIntentService"

.field static nid:I


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 38
    const/16 v0, 0x2710

    sput v0, Lcom/igg/sdk/push/IGGGCMIntentService;->nid:I

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;)V
    .locals 0
    .param p1, "senderId"    # Ljava/lang/String;

    .prologue
    .line 47
    invoke-direct {p0, p1}, Landroid/app/IntentService;-><init>(Ljava/lang/String;)V

    .line 48
    return-void
.end method

.method private generateNotification(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Class;I)V
    .locals 19
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "message"    # Ljava/lang/String;
    .param p3, "messageId"    # Ljava/lang/String;
    .param p4, "messageState"    # Ljava/lang/String;
    .param p6, "nId"    # I
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/Class",
            "<*>;I)V"
        }
    .end annotation

    .prologue
    .line 179
    .local p5, "forActivity":Ljava/lang/Class;, "Ljava/lang/Class<*>;"
    invoke-virtual/range {p0 .. p1}, Lcom/igg/sdk/push/IGGGCMIntentService;->notificationIcon(Landroid/content/Context;)I

    move-result v6

    .line 180
    .local v6, "icon":I
    invoke-virtual/range {p0 .. p1}, Lcom/igg/sdk/push/IGGGCMIntentService;->notificationTitle(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v12

    .line 182
    .local v12, "title":Ljava/lang/String;
    new-instance v9, Landroid/content/Intent;

    move-object/from16 v0, p1

    move-object/from16 v1, p5

    invoke-direct {v9, v0, v1}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    .line 183
    .local v9, "notificationIntent":Landroid/content/Intent;
    new-instance v3, Landroid/os/Bundle;

    invoke-direct {v3}, Landroid/os/Bundle;-><init>()V

    .line 184
    .local v3, "bundle":Landroid/os/Bundle;
    const-string v14, "messageId"

    move-object/from16 v0, p3

    invoke-virtual {v3, v14, v0}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 185
    const-string v14, "messageState"

    move-object/from16 v0, p4

    invoke-virtual {v3, v14, v0}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 186
    invoke-virtual {v9, v3}, Landroid/content/Intent;->putExtras(Landroid/os/Bundle;)Landroid/content/Intent;

    .line 187
    const/high16 v14, 0x24000000

    invoke-virtual {v9, v14}, Landroid/content/Intent;->setFlags(I)Landroid/content/Intent;

    .line 190
    const/4 v14, 0x0

    const/high16 v15, 0x8000000

    move-object/from16 v0, p1

    invoke-static {v0, v14, v9, v15}, Landroid/app/PendingIntent;->getActivity(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v7

    .line 193
    .local v7, "intent":Landroid/app/PendingIntent;
    invoke-static {v9}, Lcom/igg/sdk/push/IGGGCMPushNotification;->onMessage(Landroid/content/Intent;)V

    .line 195
    const/4 v8, 0x0

    .line 197
    .local v8, "notification":Landroid/app/Notification;
    const/4 v13, 0x0

    .line 199
    .local v13, "tmpSdkVersion":I
    :try_start_0
    sget v13, Landroid/os/Build$VERSION;->SDK_INT:I
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    .line 204
    :goto_0
    invoke-virtual/range {p0 .. p0}, Lcom/igg/sdk/push/IGGGCMIntentService;->getResources()Landroid/content/res/Resources;

    move-result-object v11

    .line 205
    .local v11, "res":Landroid/content/res/Resources;
    const/16 v14, 0x13

    if-le v13, v14, :cond_1

    .line 208
    :try_start_1
    invoke-virtual/range {p0 .. p1}, Lcom/igg/sdk/push/IGGGCMIntentService;->notificationIcon(Landroid/content/Context;)I

    move-result v14

    invoke-static {v11, v14}, Landroid/graphics/BitmapFactory;->decodeResource(Landroid/content/res/Resources;I)Landroid/graphics/Bitmap;

    move-result-object v2

    .line 209
    .local v2, "bt":Landroid/graphics/Bitmap;
    new-instance v14, Landroid/app/Notification$Builder;

    move-object/from16 v0, p1

    invoke-direct {v14, v0}, Landroid/app/Notification$Builder;-><init>(Landroid/content/Context;)V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v16

    move-wide/from16 v0, v16

    invoke-virtual {v14, v0, v1}, Landroid/app/Notification$Builder;->setWhen(J)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 210
    invoke-virtual {v14, v12}, Landroid/app/Notification$Builder;->setContentTitle(Ljava/lang/CharSequence;)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 211
    move-object/from16 v0, p2

    invoke-virtual {v14, v0}, Landroid/app/Notification$Builder;->setContentText(Ljava/lang/CharSequence;)Landroid/app/Notification$Builder;

    move-result-object v14

    const-string v15, "icon_status"

    const-string v16, "drawable"

    .line 212
    invoke-virtual/range {p1 .. p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v17

    move-object/from16 v0, v16

    move-object/from16 v1, v17

    invoke-virtual {v11, v15, v0, v1}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v15

    invoke-virtual {v14, v15}, Landroid/app/Notification$Builder;->setSmallIcon(I)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 213
    invoke-virtual {v14, v2}, Landroid/app/Notification$Builder;->setLargeIcon(Landroid/graphics/Bitmap;)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 214
    invoke-virtual {v14, v7}, Landroid/app/Notification$Builder;->setContentIntent(Landroid/app/PendingIntent;)Landroid/app/Notification$Builder;

    move-result-object v14

    new-instance v15, Landroid/app/Notification$BigTextStyle;

    invoke-direct {v15}, Landroid/app/Notification$BigTextStyle;-><init>()V

    .line 215
    move-object/from16 v0, p2

    invoke-virtual {v15, v0}, Landroid/app/Notification$BigTextStyle;->bigText(Ljava/lang/CharSequence;)Landroid/app/Notification$BigTextStyle;

    move-result-object v15

    invoke-virtual {v14, v15}, Landroid/app/Notification$Builder;->setStyle(Landroid/app/Notification$Style;)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 216
    invoke-virtual {v14}, Landroid/app/Notification$Builder;->build()Landroid/app/Notification;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    move-result-object v8

    .line 258
    .end local v2    # "bt":Landroid/graphics/Bitmap;
    :goto_1
    const-string v14, "notification"

    move-object/from16 v0, p1

    invoke-virtual {v0, v14}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Landroid/app/NotificationManager;

    .line 259
    .local v10, "notificationManager":Landroid/app/NotificationManager;
    if-eqz v8, :cond_0

    .line 261
    iget v14, v8, Landroid/app/Notification;->flags:I

    or-int/lit8 v14, v14, 0x11

    iput v14, v8, Landroid/app/Notification;->flags:I

    .line 262
    iget v14, v8, Landroid/app/Notification;->defaults:I

    or-int/lit8 v14, v14, 0x1

    iput v14, v8, Landroid/app/Notification;->defaults:I

    .line 263
    iget v14, v8, Landroid/app/Notification;->defaults:I

    or-int/lit8 v14, v14, 0x4

    iput v14, v8, Landroid/app/Notification;->defaults:I

    .line 264
    iget v14, v8, Landroid/app/Notification;->defaults:I

    or-int/lit8 v14, v14, 0x2

    iput v14, v8, Landroid/app/Notification;->defaults:I

    .line 265
    const v14, -0xff0100

    iput v14, v8, Landroid/app/Notification;->ledARGB:I

    .line 266
    move/from16 v0, p6

    invoke-virtual {v10, v0, v8}, Landroid/app/NotificationManager;->notify(ILandroid/app/Notification;)V

    .line 269
    :cond_0
    return-void

    .line 200
    .end local v10    # "notificationManager":Landroid/app/NotificationManager;
    .end local v11    # "res":Landroid/content/res/Resources;
    :catch_0
    move-exception v5

    .line 201
    .local v5, "e":Ljava/lang/NumberFormatException;
    invoke-virtual {v5}, Ljava/lang/NumberFormatException;->printStackTrace()V

    .line 202
    const/4 v13, 0x0

    goto/16 :goto_0

    .line 218
    .end local v5    # "e":Ljava/lang/NumberFormatException;
    .restart local v11    # "res":Landroid/content/res/Resources;
    :catch_1
    move-exception v5

    .line 219
    .local v5, "e":Ljava/lang/Exception;
    invoke-virtual {v5}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_1

    .line 222
    .end local v5    # "e":Ljava/lang/Exception;
    :cond_1
    new-instance v8, Landroid/app/Notification;

    .end local v8    # "notification":Landroid/app/Notification;
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v14

    move-object/from16 v0, p2

    invoke-direct {v8, v6, v0, v14, v15}, Landroid/app/Notification;-><init>(ILjava/lang/CharSequence;J)V

    .line 224
    .restart local v8    # "notification":Landroid/app/Notification;
    const-string v14, "notification"

    move-object/from16 v0, p1

    invoke-virtual {v0, v14}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Landroid/app/NotificationManager;

    .line 227
    .restart local v10    # "notificationManager":Landroid/app/NotificationManager;
    const/4 v4, 0x0

    .line 229
    .local v4, "deprecatedMethod":Ljava/lang/reflect/Method;
    :try_start_2
    invoke-virtual {v8}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v14

    const-string v15, "setLatestEventInfo"

    const/16 v16, 0x4

    move/from16 v0, v16

    new-array v0, v0, [Ljava/lang/Class;

    move-object/from16 v16, v0

    const/16 v17, 0x0

    const-class v18, Landroid/content/Context;

    aput-object v18, v16, v17

    const/16 v17, 0x1

    const-class v18, Ljava/lang/CharSequence;

    aput-object v18, v16, v17

    const/16 v17, 0x2

    const-class v18, Ljava/lang/CharSequence;

    aput-object v18, v16, v17

    const/16 v17, 0x3

    const-class v18, Landroid/app/PendingIntent;

    aput-object v18, v16, v17

    invoke-virtual/range {v14 .. v16}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;
    :try_end_2
    .catch Ljava/lang/NoSuchMethodException; {:try_start_2 .. :try_end_2} :catch_3

    move-result-object v4

    .line 235
    :goto_2
    const/4 v14, 0x4

    :try_start_3
    new-array v14, v14, [Ljava/lang/Object;

    const/4 v15, 0x0

    aput-object p1, v14, v15

    const/4 v15, 0x1

    aput-object v12, v14, v15

    const/4 v15, 0x2

    aput-object p2, v14, v15

    const/4 v15, 0x3

    aput-object v7, v14, v15

    invoke-virtual {v4, v8, v14}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_3
    .catch Ljava/lang/IllegalAccessException; {:try_start_3 .. :try_end_3} :catch_2
    .catch Ljava/lang/IllegalArgumentException; {:try_start_3 .. :try_end_3} :catch_4
    .catch Ljava/lang/reflect/InvocationTargetException; {:try_start_3 .. :try_end_3} :catch_5

    goto/16 :goto_1

    .line 236
    :catch_2
    move-exception v5

    .line 238
    .local v5, "e":Ljava/lang/IllegalAccessException;
    invoke-virtual {v5}, Ljava/lang/IllegalAccessException;->printStackTrace()V

    goto/16 :goto_1

    .line 230
    .end local v5    # "e":Ljava/lang/IllegalAccessException;
    :catch_3
    move-exception v5

    .line 232
    .local v5, "e":Ljava/lang/NoSuchMethodException;
    invoke-virtual {v5}, Ljava/lang/NoSuchMethodException;->printStackTrace()V

    goto :goto_2

    .line 239
    .end local v5    # "e":Ljava/lang/NoSuchMethodException;
    :catch_4
    move-exception v5

    .line 241
    .local v5, "e":Ljava/lang/IllegalArgumentException;
    invoke-virtual {v5}, Ljava/lang/IllegalArgumentException;->printStackTrace()V

    goto/16 :goto_1

    .line 242
    .end local v5    # "e":Ljava/lang/IllegalArgumentException;
    :catch_5
    move-exception v5

    .line 244
    .local v5, "e":Ljava/lang/reflect/InvocationTargetException;
    invoke-virtual {v5}, Ljava/lang/reflect/InvocationTargetException;->printStackTrace()V

    goto/16 :goto_1
.end method


# virtual methods
.method SetNotificationFlags(Landroid/app/Notification;)V
    .locals 1
    .param p1, "notification"    # Landroid/app/Notification;

    .prologue
    .line 272
    iget v0, p1, Landroid/app/Notification;->flags:I

    or-int/lit8 v0, v0, 0x11

    iput v0, p1, Landroid/app/Notification;->flags:I

    .line 273
    iget v0, p1, Landroid/app/Notification;->defaults:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p1, Landroid/app/Notification;->defaults:I

    .line 274
    iget v0, p1, Landroid/app/Notification;->defaults:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p1, Landroid/app/Notification;->defaults:I

    .line 275
    iget v0, p1, Landroid/app/Notification;->defaults:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p1, Landroid/app/Notification;->defaults:I

    .line 276
    const v0, -0xff0100

    iput v0, p1, Landroid/app/Notification;->ledARGB:I

    .line 277
    return-void
.end method

.method protected getLaunchActivity(Landroid/content/Context;)Ljava/lang/Class;
    .locals 4
    .param p1, "context"    # Landroid/content/Context;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            ")",
            "Ljava/lang/Class",
            "<*>;"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/ClassNotFoundException;
        }
    .end annotation

    .prologue
    .line 291
    :try_start_0
    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    invoke-virtual {v3}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    .line 292
    .local v2, "packageName":Ljava/lang/String;
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v3

    .line 293
    invoke-virtual {v3, v2}, Landroid/content/pm/PackageManager;->getLaunchIntentForPackage(Ljava/lang/String;)Landroid/content/Intent;

    move-result-object v3

    .line 294
    invoke-virtual {v3}, Landroid/content/Intent;->getComponent()Landroid/content/ComponentName;

    move-result-object v3

    invoke-virtual {v3}, Landroid/content/ComponentName;->getClassName()Ljava/lang/String;

    move-result-object v0

    .line 295
    .local v0, "classname":Ljava/lang/String;
    invoke-static {v0}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v3

    .line 298
    .end local v0    # "classname":Ljava/lang/String;
    .end local v2    # "packageName":Ljava/lang/String;
    :goto_0
    return-object v3

    .line 296
    :catch_0
    move-exception v1

    .line 297
    .local v1, "e":Ljava/lang/Exception;
    invoke-virtual {v1}, Ljava/lang/Exception;->printStackTrace()V

    .line 298
    const/4 v3, 0x0

    goto :goto_0
.end method

.method protected messageHandler(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 9
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "intent"    # Landroid/content/Intent;

    .prologue
    .line 128
    :try_start_0
    invoke-virtual {p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v0

    const-string v1, "msg"

    invoke-virtual {v0, v1}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 129
    .local v2, "msg":Ljava/lang/String;
    invoke-virtual {p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v0

    const-string v1, "m_qid"

    invoke-virtual {v0, v1}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 130
    .local v3, "messageId":Ljava/lang/String;
    invoke-static {p1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->getAPPState(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v4

    .line 131
    .local v4, "messageState":Ljava/lang/String;
    sget v0, Lcom/igg/sdk/push/IGGGCMIntentService;->nid:I

    add-int/lit8 v0, v0, 0x1

    sput v0, Lcom/igg/sdk/push/IGGGCMIntentService;->nid:I

    .line 132
    if-eqz v2, :cond_0

    const-string v0, ""

    invoke-virtual {v2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 133
    invoke-virtual {p0, p1}, Lcom/igg/sdk/push/IGGGCMIntentService;->getLaunchActivity(Landroid/content/Context;)Ljava/lang/Class;

    move-result-object v8

    .line 134
    .local v8, "forActivity":Ljava/lang/Class;, "Ljava/lang/Class<*>;"
    if-eqz v8, :cond_0

    .line 135
    invoke-virtual {p0, p1}, Lcom/igg/sdk/push/IGGGCMIntentService;->getLaunchActivity(Landroid/content/Context;)Ljava/lang/Class;

    move-result-object v5

    sget v6, Lcom/igg/sdk/push/IGGGCMIntentService;->nid:I

    move-object v0, p0

    move-object v1, p1

    invoke-direct/range {v0 .. v6}, Lcom/igg/sdk/push/IGGGCMIntentService;->generateNotification(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Class;I)V
    :try_end_0
    .catch Ljava/lang/ClassNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    .line 141
    .end local v2    # "msg":Ljava/lang/String;
    .end local v3    # "messageId":Ljava/lang/String;
    .end local v4    # "messageState":Ljava/lang/String;
    .end local v8    # "forActivity":Ljava/lang/Class;, "Ljava/lang/Class<*>;"
    :cond_0
    :goto_0
    return-void

    .line 138
    :catch_0
    move-exception v7

    .line 139
    .local v7, "e":Ljava/lang/ClassNotFoundException;
    invoke-virtual {v7}, Ljava/lang/ClassNotFoundException;->printStackTrace()V

    goto :goto_0
.end method

.method protected notificationIcon(Landroid/content/Context;)I
    .locals 1
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 166
    sget v0, Lcom/igg/sdk/R$drawable;->ic_stat_gcm:I

    return v0
.end method

.method protected notificationTitle(Landroid/content/Context;)Ljava/lang/String;
    .locals 1
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 153
    sget v0, Lcom/igg/sdk/R$string;->app_name:I

    invoke-virtual {p1, v0}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method protected onHandleIntent(Landroid/content/Intent;)V
    .locals 14
    .param p1, "intent"    # Landroid/content/Intent;

    .prologue
    .line 55
    const-string v10, "IGGGCMIntentService"

    const-string v11, "--------onHandleIntent------"

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 56
    if-nez p1, :cond_1

    .line 113
    :cond_0
    :goto_0
    return-void

    .line 60
    :cond_1
    invoke-virtual {p1}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v10

    if-eqz v10, :cond_0

    .line 63
    invoke-virtual {p0}, Lcom/igg/sdk/push/IGGGCMIntentService;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    .line 64
    .local v1, "context":Landroid/content/Context;
    invoke-virtual {p1}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v4

    .line 65
    .local v4, "extras":Landroid/os/Bundle;
    invoke-static {p0}, Lcom/google/android/gms/gcm/GoogleCloudMessaging;->getInstance(Landroid/content/Context;)Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    move-result-object v5

    .line 66
    .local v5, "gcm":Lcom/google/android/gms/gcm/GoogleCloudMessaging;
    invoke-virtual {v5, p1}, Lcom/google/android/gms/gcm/GoogleCloudMessaging;->getMessageType(Landroid/content/Intent;)Ljava/lang/String;

    move-result-object v8

    .line 67
    .local v8, "messageType":Ljava/lang/String;
    invoke-virtual {v4}, Landroid/os/Bundle;->isEmpty()Z

    move-result v10

    if-nez v10, :cond_2

    .line 68
    const-string v10, "send_error"

    invoke-virtual {v10, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-eqz v10, :cond_3

    .line 69
    const-string v10, "onHandleIntent"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "Send error: "

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v4}, Landroid/os/Bundle;->toString()Ljava/lang/String;

    move-result-object v12

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 112
    :cond_2
    :goto_1
    invoke-static {p1}, Lcom/igg/sdk/push/IGGGcmBroadcastReceiver;->completeWakefulIntent(Landroid/content/Intent;)Z

    goto :goto_0

    .line 70
    :cond_3
    const-string v10, "deleted_messages"

    invoke-virtual {v10, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-eqz v10, :cond_4

    .line 71
    const-string v10, "onHandleIntent"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "Deleted messages on server: "

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v4}, Landroid/os/Bundle;->toString()Ljava/lang/String;

    move-result-object v12

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1

    .line 72
    :cond_4
    const-string v10, "gcm"

    invoke-virtual {v10, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-eqz v10, :cond_2

    .line 74
    const/4 v6, 0x0

    .local v6, "i":I
    :goto_2
    const/4 v10, 0x4

    if-ge v6, v10, :cond_5

    .line 75
    const-string v10, "GCMIntentService"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "Working... "

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    add-int/lit8 v12, v6, 0x1

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v11

    const-string v12, "/4 @ "

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-static {}, Landroid/os/SystemClock;->elapsedRealtime()J

    move-result-wide v12

    invoke-virtual {v11, v12, v13}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 77
    const-wide/16 v10, 0xfa0

    :try_start_0
    invoke-static {v10, v11}, Ljava/lang/Thread;->sleep(J)V
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0

    .line 74
    :goto_3
    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    .line 78
    :catch_0
    move-exception v3

    .line 79
    .local v3, "e":Ljava/lang/InterruptedException;
    const-string v10, "onHandleIntent"

    invoke-virtual {v3}, Ljava/lang/InterruptedException;->getMessage()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_3

    .line 83
    .end local v3    # "e":Ljava/lang/InterruptedException;
    :cond_5
    new-instance v9, Landroid/content/Intent;

    invoke-direct {v9}, Landroid/content/Intent;-><init>()V

    .line 84
    .local v9, "newIntent":Landroid/content/Intent;
    if-eqz v9, :cond_6

    .line 86
    const-string v10, "action.IGGNotification_message_rceiver"

    invoke-virtual {v9, v10}, Landroid/content/Intent;->setAction(Ljava/lang/String;)Landroid/content/Intent;

    .line 87
    invoke-static {v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->getAPPState(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v7

    .line 88
    .local v7, "messageState":Ljava/lang/String;
    invoke-virtual {p1}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v0

    .line 89
    .local v0, "bundle":Landroid/os/Bundle;
    const-string v10, "m_state"

    invoke-virtual {v0, v10, v7}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 90
    invoke-virtual {v9, v0}, Landroid/content/Intent;->putExtras(Landroid/os/Bundle;)Landroid/content/Intent;

    .line 91
    invoke-virtual {p0, v9}, Lcom/igg/sdk/push/IGGGCMIntentService;->sendBroadcast(Landroid/content/Intent;)V

    .line 94
    .end local v0    # "bundle":Landroid/os/Bundle;
    .end local v7    # "messageState":Ljava/lang/String;
    :cond_6
    invoke-virtual {p1}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v10

    const-string v11, "m_crm"

    invoke-virtual {v10, v11}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 95
    .local v2, "crm":Ljava/lang/String;
    if-eqz v2, :cond_7

    .line 96
    const-string v10, "GCMIntentService"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "IGGGCMIntentService:crm Message:"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 100
    :cond_7
    const-string v10, "GCMIntentService"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "\u5f53\u524d\u7684 APP \u8fd0\u884c\u72b6\u6001:"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-static {v1}, Lcom/igg/util/DeviceUtil;->isAPPRun(Landroid/content/Context;)Z

    move-result v12

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 103
    invoke-static {}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->sharedInstance()Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    move-result-object v10

    invoke-virtual {v10}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->getConfig()Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;

    move-result-object v10

    invoke-virtual {v10, v1}, Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;->isCustomHandle(Landroid/content/Context;)Z

    move-result v10

    if-nez v10, :cond_2

    .line 104
    const-string v10, "GCMIntentService"

    const-string v11, "Push Message no Custom Handle"

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 106
    invoke-virtual {p0, v1, p1}, Lcom/igg/sdk/push/IGGGCMIntentService;->messageHandler(Landroid/content/Context;Landroid/content/Intent;)V

    goto/16 :goto_1
.end method
