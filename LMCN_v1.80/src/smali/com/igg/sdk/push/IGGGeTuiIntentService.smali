.class public abstract Lcom/igg/sdk/push/IGGGeTuiIntentService;
.super Landroid/content/BroadcastReceiver;
.source "IGGGeTuiIntentService.java"


# static fields
.field public static final GETUI_PUSH_TYPE:Ljava/lang/String; = "7"

.field private static final TAG:Ljava/lang/String; = "IGGGeTuiIntentService"

.field static nid:I


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 40
    const/16 v0, 0x2710

    sput v0, Lcom/igg/sdk/push/IGGGeTuiIntentService;->nid:I

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 38
    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V

    return-void
.end method


# virtual methods
.method protected generateNotification(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Class;)V
    .locals 19
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "message"    # Ljava/lang/String;
    .param p3, "messageId"    # Ljava/lang/String;
    .param p4, "messageState"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/Class",
            "<*>;)V"
        }
    .end annotation

    .prologue
    .line 203
    .local p5, "forActivity":Ljava/lang/Class;, "Ljava/lang/Class<*>;"
    invoke-virtual/range {p0 .. p1}, Lcom/igg/sdk/push/IGGGeTuiIntentService;->notificationIcon(Landroid/content/Context;)I

    move-result v6

    .line 204
    .local v6, "icon":I
    invoke-virtual/range {p0 .. p1}, Lcom/igg/sdk/push/IGGGeTuiIntentService;->notificationTitle(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v12

    .line 206
    .local v12, "title":Ljava/lang/String;
    new-instance v9, Landroid/content/Intent;

    move-object/from16 v0, p1

    move-object/from16 v1, p5

    invoke-direct {v9, v0, v1}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    .line 207
    .local v9, "notificationIntent":Landroid/content/Intent;
    new-instance v3, Landroid/os/Bundle;

    invoke-direct {v3}, Landroid/os/Bundle;-><init>()V

    .line 208
    .local v3, "bundle":Landroid/os/Bundle;
    const-string v14, "messageId"

    move-object/from16 v0, p3

    invoke-virtual {v3, v14, v0}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 209
    const-string v14, "messageState"

    move-object/from16 v0, p4

    invoke-virtual {v3, v14, v0}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 210
    invoke-virtual {v9, v3}, Landroid/content/Intent;->putExtras(Landroid/os/Bundle;)Landroid/content/Intent;

    .line 211
    const/high16 v14, 0x24000000

    invoke-virtual {v9, v14}, Landroid/content/Intent;->setFlags(I)Landroid/content/Intent;

    .line 214
    const/4 v14, 0x0

    const/high16 v15, 0x8000000

    move-object/from16 v0, p1

    invoke-static {v0, v14, v9, v15}, Landroid/app/PendingIntent;->getActivity(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v7

    .line 216
    .local v7, "intent":Landroid/app/PendingIntent;
    invoke-static {v9}, Lcom/igg/sdk/push/IGGGCMPushNotification;->onMessage(Landroid/content/Intent;)V

    .line 219
    const/4 v13, 0x0

    .line 221
    .local v13, "tmpSdkVersion":I
    :try_start_0
    sget v13, Landroid/os/Build$VERSION;->SDK_INT:I
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    .line 226
    :goto_0
    const/16 v14, 0x13

    if-le v13, v14, :cond_0

    .line 228
    invoke-virtual/range {p1 .. p1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v11

    .line 229
    .local v11, "res":Landroid/content/res/Resources;
    invoke-virtual/range {p0 .. p1}, Lcom/igg/sdk/push/IGGGeTuiIntentService;->notificationIcon(Landroid/content/Context;)I

    move-result v14

    invoke-static {v11, v14}, Landroid/graphics/BitmapFactory;->decodeResource(Landroid/content/res/Resources;I)Landroid/graphics/Bitmap;

    move-result-object v2

    .line 230
    .local v2, "bt":Landroid/graphics/Bitmap;
    new-instance v14, Landroid/app/Notification$Builder;

    move-object/from16 v0, p1

    invoke-direct {v14, v0}, Landroid/app/Notification$Builder;-><init>(Landroid/content/Context;)V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v16

    move-wide/from16 v0, v16

    invoke-virtual {v14, v0, v1}, Landroid/app/Notification$Builder;->setWhen(J)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 231
    invoke-virtual {v14, v12}, Landroid/app/Notification$Builder;->setContentTitle(Ljava/lang/CharSequence;)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 232
    move-object/from16 v0, p2

    invoke-virtual {v14, v0}, Landroid/app/Notification$Builder;->setContentText(Ljava/lang/CharSequence;)Landroid/app/Notification$Builder;

    move-result-object v14

    const-string v15, "icon_status"

    const-string v16, "drawable"

    .line 233
    invoke-virtual/range {p1 .. p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v17

    move-object/from16 v0, v16

    move-object/from16 v1, v17

    invoke-virtual {v11, v15, v0, v1}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v15

    invoke-virtual {v14, v15}, Landroid/app/Notification$Builder;->setSmallIcon(I)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 234
    invoke-virtual {v14, v2}, Landroid/app/Notification$Builder;->setLargeIcon(Landroid/graphics/Bitmap;)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 235
    invoke-virtual {v14, v7}, Landroid/app/Notification$Builder;->setContentIntent(Landroid/app/PendingIntent;)Landroid/app/Notification$Builder;

    move-result-object v14

    new-instance v15, Landroid/app/Notification$BigTextStyle;

    invoke-direct {v15}, Landroid/app/Notification$BigTextStyle;-><init>()V

    .line 236
    move-object/from16 v0, p2

    invoke-virtual {v15, v0}, Landroid/app/Notification$BigTextStyle;->bigText(Ljava/lang/CharSequence;)Landroid/app/Notification$BigTextStyle;

    move-result-object v15

    invoke-virtual {v14, v15}, Landroid/app/Notification$Builder;->setStyle(Landroid/app/Notification$Style;)Landroid/app/Notification$Builder;

    move-result-object v14

    .line 237
    invoke-virtual {v14}, Landroid/app/Notification$Builder;->build()Landroid/app/Notification;

    move-result-object v8

    .line 272
    .end local v2    # "bt":Landroid/graphics/Bitmap;
    .end local v11    # "res":Landroid/content/res/Resources;
    .local v8, "notification":Landroid/app/Notification;
    :goto_1
    iget v14, v8, Landroid/app/Notification;->flags:I

    or-int/lit8 v14, v14, 0x11

    iput v14, v8, Landroid/app/Notification;->flags:I

    .line 273
    iget v14, v8, Landroid/app/Notification;->defaults:I

    or-int/lit8 v14, v14, 0x1

    iput v14, v8, Landroid/app/Notification;->defaults:I

    .line 274
    iget v14, v8, Landroid/app/Notification;->defaults:I

    or-int/lit8 v14, v14, 0x4

    iput v14, v8, Landroid/app/Notification;->defaults:I

    .line 275
    iget v14, v8, Landroid/app/Notification;->defaults:I

    or-int/lit8 v14, v14, 0x2

    iput v14, v8, Landroid/app/Notification;->defaults:I

    .line 276
    const v14, -0xff0100

    iput v14, v8, Landroid/app/Notification;->ledARGB:I

    .line 282
    sget v14, Lcom/igg/sdk/push/IGGGeTuiIntentService;->nid:I

    add-int/lit8 v14, v14, 0x1

    sput v14, Lcom/igg/sdk/push/IGGGeTuiIntentService;->nid:I

    .line 283
    const-string v14, "notification"

    move-object/from16 v0, p1

    invoke-virtual {v0, v14}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Landroid/app/NotificationManager;

    .line 284
    .local v10, "notificationManager":Landroid/app/NotificationManager;
    sget v14, Lcom/igg/sdk/push/IGGGeTuiIntentService;->nid:I

    invoke-virtual {v10, v14, v8}, Landroid/app/NotificationManager;->notify(ILandroid/app/Notification;)V

    .line 285
    return-void

    .line 222
    .end local v8    # "notification":Landroid/app/Notification;
    .end local v10    # "notificationManager":Landroid/app/NotificationManager;
    :catch_0
    move-exception v5

    .line 223
    .local v5, "e":Ljava/lang/NumberFormatException;
    const/4 v13, 0x0

    goto/16 :goto_0

    .line 246
    .end local v5    # "e":Ljava/lang/NumberFormatException;
    :cond_0
    new-instance v8, Landroid/app/Notification;

    invoke-direct {v8}, Landroid/app/Notification;-><init>()V

    .line 247
    .restart local v8    # "notification":Landroid/app/Notification;
    iput v6, v8, Landroid/app/Notification;->icon:I

    .line 250
    :try_start_1
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

    move-result-object v4

    .line 251
    .local v4, "deprecatedMethod":Ljava/lang/reflect/Method;
    const/4 v14, 0x4

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
    :try_end_1
    .catch Ljava/lang/NoSuchMethodException; {:try_start_1 .. :try_end_1} :catch_1
    .catch Ljava/lang/IllegalAccessException; {:try_start_1 .. :try_end_1} :catch_2
    .catch Ljava/lang/IllegalArgumentException; {:try_start_1 .. :try_end_1} :catch_3
    .catch Ljava/lang/reflect/InvocationTargetException; {:try_start_1 .. :try_end_1} :catch_4

    goto :goto_1

    .line 252
    .end local v4    # "deprecatedMethod":Ljava/lang/reflect/Method;
    :catch_1
    move-exception v5

    .line 253
    .local v5, "e":Ljava/lang/NoSuchMethodException;
    const-string v14, "IGGGeTuiIntentService"

    const-string v15, "Method not found"

    invoke-static {v14, v15, v5}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    goto/16 :goto_1

    .line 255
    .end local v5    # "e":Ljava/lang/NoSuchMethodException;
    :catch_2
    move-exception v5

    .line 256
    .local v5, "e":Ljava/lang/IllegalAccessException;
    const-string v14, "IGGGeTuiIntentService"

    const-string v15, "Method not found"

    invoke-static {v14, v15, v5}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    goto/16 :goto_1

    .line 258
    .end local v5    # "e":Ljava/lang/IllegalAccessException;
    :catch_3
    move-exception v5

    .line 259
    .local v5, "e":Ljava/lang/IllegalArgumentException;
    const-string v14, "IGGGeTuiIntentService"

    const-string v15, "Method not found"

    invoke-static {v14, v15, v5}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    goto/16 :goto_1

    .line 261
    .end local v5    # "e":Ljava/lang/IllegalArgumentException;
    :catch_4
    move-exception v5

    .line 262
    .local v5, "e":Ljava/lang/reflect/InvocationTargetException;
    const-string v14, "IGGGeTuiIntentService"

    const-string v15, "Method not found"

    invoke-static {v14, v15, v5}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    goto/16 :goto_1
.end method

.method protected getLaunchActivity(Landroid/content/Context;)Ljava/lang/Class;
    .locals 3
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
    .line 323
    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v2

    invoke-virtual {v2}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v1

    .line 324
    .local v1, "packageName":Ljava/lang/String;
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    .line 325
    invoke-virtual {v2, v1}, Landroid/content/pm/PackageManager;->getLaunchIntentForPackage(Ljava/lang/String;)Landroid/content/Intent;

    move-result-object v2

    .line 326
    invoke-virtual {v2}, Landroid/content/Intent;->getComponent()Landroid/content/ComponentName;

    move-result-object v2

    invoke-virtual {v2}, Landroid/content/ComponentName;->getClassName()Ljava/lang/String;

    move-result-object v0

    .line 327
    .local v0, "classname":Ljava/lang/String;
    invoke-static {v0}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v2

    return-object v2
.end method

.method public isAppInForeground(Landroid/content/Context;)Z
    .locals 7
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    const/4 v5, 0x0

    const/4 v4, 0x1

    .line 296
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v3

    if-eqz v3, :cond_0

    .line 297
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v3

    const-string v6, "activity"

    .line 298
    invoke-virtual {v3, v6}, Landroid/app/Application;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/app/ActivityManager;

    .line 299
    .local v0, "am":Landroid/app/ActivityManager;
    invoke-virtual {v0, v4}, Landroid/app/ActivityManager;->getRunningTasks(I)Ljava/util/List;

    move-result-object v1

    .line 300
    .local v1, "tasks":Ljava/util/List;, "Ljava/util/List<Landroid/app/ActivityManager$RunningTaskInfo;>;"
    invoke-interface {v1}, Ljava/util/List;->isEmpty()Z

    move-result v3

    if-nez v3, :cond_1

    .line 301
    invoke-interface {v1, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroid/app/ActivityManager$RunningTaskInfo;

    iget-object v2, v3, Landroid/app/ActivityManager$RunningTaskInfo;->topActivity:Landroid/content/ComponentName;

    .line 302
    .local v2, "topActivity":Landroid/content/ComponentName;
    invoke-virtual {v2}, Landroid/content/ComponentName;->getPackageName()Ljava/lang/String;

    move-result-object v3

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    invoke-virtual {v6}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v6

    invoke-virtual {v6}, Landroid/app/Application;->getPackageName()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_1

    move v3, v4

    .line 318
    .end local v2    # "topActivity":Landroid/content/ComponentName;
    :goto_0
    return v3

    .line 307
    .end local v0    # "am":Landroid/app/ActivityManager;
    .end local v1    # "tasks":Ljava/util/List;, "Ljava/util/List<Landroid/app/ActivityManager$RunningTaskInfo;>;"
    :cond_0
    const-string v3, "activity"

    .line 308
    invoke-virtual {p1, v3}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/app/ActivityManager;

    .line 309
    .restart local v0    # "am":Landroid/app/ActivityManager;
    invoke-virtual {v0, v4}, Landroid/app/ActivityManager;->getRunningTasks(I)Ljava/util/List;

    move-result-object v1

    .line 310
    .restart local v1    # "tasks":Ljava/util/List;, "Ljava/util/List<Landroid/app/ActivityManager$RunningTaskInfo;>;"
    invoke-interface {v1}, Ljava/util/List;->isEmpty()Z

    move-result v3

    if-nez v3, :cond_1

    .line 311
    invoke-interface {v1, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroid/app/ActivityManager$RunningTaskInfo;

    iget-object v2, v3, Landroid/app/ActivityManager$RunningTaskInfo;->topActivity:Landroid/content/ComponentName;

    .line 312
    .restart local v2    # "topActivity":Landroid/content/ComponentName;
    invoke-virtual {v2}, Landroid/content/ComponentName;->getPackageName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_1

    move v3, v4

    .line 313
    goto :goto_0

    .end local v2    # "topActivity":Landroid/content/ComponentName;
    :cond_1
    move v3, v5

    .line 318
    goto :goto_0
.end method

.method protected abstract notificationIcon(Landroid/content/Context;)I
.end method

.method protected abstract notificationTitle(Landroid/content/Context;)Ljava/lang/String;
.end method

.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 27
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "intent"    # Landroid/content/Intent;

    .prologue
    .line 48
    invoke-virtual/range {p2 .. p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v15

    .line 49
    .local v15, "bundle":Landroid/os/Bundle;
    const-string v2, "IGGGeTuiIntentService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "onReceive() action:"

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v7, "action"

    invoke-virtual {v15, v7}, Landroid/os/Bundle;->getInt(Ljava/lang/String;)I

    move-result v7

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 50
    const-string v2, "action"

    invoke-virtual {v15, v2}, Landroid/os/Bundle;->getInt(Ljava/lang/String;)I

    move-result v2

    packed-switch v2, :pswitch_data_0

    .line 195
    :cond_0
    :goto_0
    return-void

    .line 53
    :pswitch_0
    const-string v2, "payload"

    invoke-virtual {v15, v2}, Landroid/os/Bundle;->getByteArray(Ljava/lang/String;)[B

    move-result-object v22

    .line 54
    .local v22, "payload":[B
    if-eqz v22, :cond_0

    .line 55
    new-instance v17, Ljava/lang/String;

    move-object/from16 v0, v17

    move-object/from16 v1, v22

    invoke-direct {v0, v1}, Ljava/lang/String;-><init>([B)V

    .line 56
    .local v17, "data":Ljava/lang/String;
    const-string v2, "IGGGeTuiIntentService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "Get payload data:"

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    move-object/from16 v0, v17

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 57
    if-eqz v17, :cond_0

    .line 59
    :try_start_0
    new-instance v23, Lorg/json/JSONObject;

    move-object/from16 v0, v23

    move-object/from16 v1, v17

    invoke-direct {v0, v1}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 60
    .local v23, "pushData":Lorg/json/JSONObject;
    new-instance v21, Landroid/content/Intent;

    invoke-direct/range {v21 .. v21}, Landroid/content/Intent;-><init>()V

    .line 61
    .local v21, "newIntent":Landroid/content/Intent;
    if-eqz v21, :cond_3

    .line 62
    new-instance v20, Landroid/os/Bundle;

    invoke-direct/range {v20 .. v20}, Landroid/os/Bundle;-><init>()V

    .line 63
    .local v20, "newBundle":Landroid/os/Bundle;
    const-string v2, "msg"

    move-object/from16 v0, v23

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v19

    .line 64
    .local v19, "message":Ljava/lang/String;
    const-string v2, "m_qid"

    move-object/from16 v0, v23

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v24

    .line 66
    .local v24, "qid":Ljava/lang/String;
    const-string v2, "id"

    move-object/from16 v0, v23

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_1

    .line 67
    const-string v2, "id"

    move-object/from16 v0, v23

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v16

    .line 68
    .local v16, "crm":Ljava/lang/String;
    const-string v2, "id"

    move-object/from16 v0, v20

    move-object/from16 v1, v16

    invoke-virtual {v0, v2, v1}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 71
    .end local v16    # "crm":Ljava/lang/String;
    :cond_1
    const-string v2, "m_crm"

    move-object/from16 v0, v23

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_2

    .line 72
    const-string v2, "m_crm"

    move-object/from16 v0, v23

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v16

    .line 73
    .restart local v16    # "crm":Ljava/lang/String;
    const-string v2, "m_crm"

    move-object/from16 v0, v20

    move-object/from16 v1, v16

    invoke-virtual {v0, v2, v1}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 76
    .end local v16    # "crm":Ljava/lang/String;
    :cond_2
    const-string v2, "msg"

    move-object/from16 v0, v20

    move-object/from16 v1, v19

    invoke-virtual {v0, v2, v1}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 77
    const-string v2, "m_qid"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v2, v1}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 81
    const-string v2, "action.IGGNotification_message_rceiver"

    move-object/from16 v0, v21

    invoke-virtual {v0, v2}, Landroid/content/Intent;->setAction(Ljava/lang/String;)Landroid/content/Intent;

    .line 82
    invoke-static/range {p1 .. p1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->getAPPState(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v6

    .line 84
    .local v6, "messageState":Ljava/lang/String;
    const-string v2, "m_state"

    move-object/from16 v0, v20

    invoke-virtual {v0, v2, v6}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 85
    move-object/from16 v0, v21

    move-object/from16 v1, v20

    invoke-virtual {v0, v1}, Landroid/content/Intent;->putExtras(Landroid/os/Bundle;)Landroid/content/Intent;

    .line 86
    move-object/from16 v0, p1

    move-object/from16 v1, v21

    invoke-virtual {v0, v1}, Landroid/content/Context;->sendBroadcast(Landroid/content/Intent;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_1

    .line 90
    .end local v6    # "messageState":Ljava/lang/String;
    .end local v19    # "message":Ljava/lang/String;
    .end local v20    # "newBundle":Landroid/os/Bundle;
    .end local v24    # "qid":Ljava/lang/String;
    :cond_3
    :try_start_1
    const-string v2, "msg"

    move-object/from16 v0, v23

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 91
    .local v4, "msg":Ljava/lang/String;
    const-string v2, "m_crm"

    move-object/from16 v0, v23

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_4

    .line 92
    const-string v2, "IGGGeTuiIntentService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "IGGGeTuiIntentService:crm Message:"

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v7, "m_crm"

    move-object/from16 v0, v23

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catch Ljava/lang/ClassNotFoundException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_1

    goto/16 :goto_0

    .line 105
    .end local v4    # "msg":Ljava/lang/String;
    :catch_0
    move-exception v18

    .line 106
    .local v18, "e":Ljava/lang/ClassNotFoundException;
    :try_start_2
    invoke-virtual/range {v18 .. v18}, Ljava/lang/ClassNotFoundException;->printStackTrace()V
    :try_end_2
    .catch Lorg/json/JSONException; {:try_start_2 .. :try_end_2} :catch_1

    goto/16 :goto_0

    .line 140
    .end local v18    # "e":Ljava/lang/ClassNotFoundException;
    .end local v21    # "newIntent":Landroid/content/Intent;
    .end local v23    # "pushData":Lorg/json/JSONObject;
    :catch_1
    move-exception v18

    .line 141
    .local v18, "e":Lorg/json/JSONException;
    const-string v2, "IGGGeTuiIntentService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "Data format error:"

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    move-object/from16 v0, v17

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 142
    const-string v2, "IGGGeTuiIntentService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "Data format error:"

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual/range {v18 .. v18}, Lorg/json/JSONException;->getMessage()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 96
    .end local v18    # "e":Lorg/json/JSONException;
    .restart local v4    # "msg":Ljava/lang/String;
    .restart local v21    # "newIntent":Landroid/content/Intent;
    .restart local v23    # "pushData":Lorg/json/JSONObject;
    :cond_4
    :try_start_3
    invoke-static {}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->sharedInstance()Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->getConfig()Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;

    move-result-object v2

    move-object/from16 v0, p1

    invoke-virtual {v2, v0}, Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;->isCustomHandle(Landroid/content/Context;)Z

    move-result v2

    if-nez v2, :cond_0

    .line 97
    const-string v2, "IGGGeTuiIntentService"

    const-string v3, "Push Message no Custom Handle"

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 98
    const-string v2, "m_qid"

    move-object/from16 v0, v23

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 99
    .local v5, "messageId":Ljava/lang/String;
    const-string v2, "IGGGeTuiIntentService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "messageId:"

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 100
    invoke-static/range {p1 .. p1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->getAPPState(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v6

    .line 101
    .restart local v6    # "messageState":Ljava/lang/String;
    if-eqz v4, :cond_0

    const-string v2, ""

    invoke-virtual {v4, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_0

    .line 102
    invoke-virtual/range {p0 .. p1}, Lcom/igg/sdk/push/IGGGeTuiIntentService;->getLaunchActivity(Landroid/content/Context;)Ljava/lang/Class;

    move-result-object v7

    move-object/from16 v2, p0

    move-object/from16 v3, p1

    invoke-virtual/range {v2 .. v7}, Lcom/igg/sdk/push/IGGGeTuiIntentService;->generateNotification(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Class;)V
    :try_end_3
    .catch Ljava/lang/ClassNotFoundException; {:try_start_3 .. :try_end_3} :catch_0
    .catch Lorg/json/JSONException; {:try_start_3 .. :try_end_3} :catch_1

    goto/16 :goto_0

    .line 150
    .end local v4    # "msg":Ljava/lang/String;
    .end local v5    # "messageId":Ljava/lang/String;
    .end local v6    # "messageState":Ljava/lang/String;
    .end local v17    # "data":Ljava/lang/String;
    .end local v21    # "newIntent":Landroid/content/Intent;
    .end local v22    # "payload":[B
    .end local v23    # "pushData":Lorg/json/JSONObject;
    :pswitch_1
    const-string v2, "clientid"

    invoke-virtual {v15, v2}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v11

    .line 151
    .local v11, "registrationId":Ljava/lang/String;
    const-string v2, "IGGGeTuiIntentService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "registrationId:"

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 154
    new-instance v26, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;

    move-object/from16 v0, v26

    move-object/from16 v1, p1

    invoke-direct {v0, v1}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;-><init>(Landroid/content/Context;)V

    .line 155
    .local v26, "serivce":Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
    invoke-virtual/range {v26 .. v26}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->currentRegId()Ljava/lang/String;

    move-result-object v25

    .line 156
    .local v25, "regId":Ljava/lang/String;
    invoke-virtual/range {v26 .. v26}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->currentIGGId()Ljava/lang/String;

    move-result-object v12

    .line 157
    .local v12, "iggId":Ljava/lang/String;
    invoke-virtual/range {v26 .. v26}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->currentGameId()Ljava/lang/String;

    move-result-object v9

    .line 179
    .local v9, "gameId":Ljava/lang/String;
    move-object/from16 v0, v26

    invoke-virtual {v0, v11}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->setRegId(Ljava/lang/String;)V

    .line 180
    const-string v2, "IGGGeTuiIntentService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "storaged registrationId: "

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    move-object/from16 v0, v25

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 181
    const-string v2, "IGGGeTuiIntentService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "current registrationId: "

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 183
    new-instance v7, Lcom/igg/sdk/service/IGGMobileDeviceService;

    invoke-direct {v7}, Lcom/igg/sdk/service/IGGMobileDeviceService;-><init>()V

    const-string v10, "7"

    const-string v13, ""

    new-instance v14, Lcom/igg/sdk/push/IGGGeTuiIntentService$1;

    move-object/from16 v0, p0

    invoke-direct {v14, v0, v11}, Lcom/igg/sdk/push/IGGGeTuiIntentService$1;-><init>(Lcom/igg/sdk/push/IGGGeTuiIntentService;Ljava/lang/String;)V

    move-object/from16 v8, p1

    invoke-virtual/range {v7 .. v14}, Lcom/igg/sdk/service/IGGMobileDeviceService;->registerDevice(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;)V

    goto/16 :goto_0

    .line 50
    :pswitch_data_0
    .packed-switch 0x2711
        :pswitch_0
        :pswitch_1
    .end packed-switch
.end method
