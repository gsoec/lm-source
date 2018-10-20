.class public Lcom/igg/iggsdkbusiness/LocalNotificationReceiver;
.super Landroid/content/BroadcastReceiver;
.source "LocalNotificationReceiver.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 26
    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V

    return-void
.end method


# virtual methods
.method protected GetLocalTitle()Ljava/lang/String;
    .locals 1

    .prologue
    .line 124
    const-string v0, "\u738b\u56fd\u7eaa\u5143"

    return-object v0
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
            Ljava/lang/ClassNotFoundException;,
            Ljava/lang/NullPointerException;
        }
    .end annotation

    .prologue
    .line 129
    :try_start_0
    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    invoke-virtual {v3}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    .line 130
    .local v2, "packageName":Ljava/lang/String;
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v3

    .line 131
    invoke-virtual {v3, v2}, Landroid/content/pm/PackageManager;->getLaunchIntentForPackage(Ljava/lang/String;)Landroid/content/Intent;

    move-result-object v3

    .line 132
    invoke-virtual {v3}, Landroid/content/Intent;->getComponent()Landroid/content/ComponentName;

    move-result-object v3

    invoke-virtual {v3}, Landroid/content/ComponentName;->getClassName()Ljava/lang/String;

    move-result-object v0

    .line 133
    .local v0, "classname":Ljava/lang/String;
    invoke-static {v0}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;
    :try_end_0
    .catch Ljava/lang/NullPointerException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v3

    return-object v3

    .line 135
    .end local v0    # "classname":Ljava/lang/String;
    .end local v2    # "packageName":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 136
    .local v1, "e":Ljava/lang/NullPointerException;
    throw v1
.end method

.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 23
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "intent"    # Landroid/content/Intent;

    .prologue
    .line 31
    const-string v18, "Alarm"

    const-string v19, "onReceive - Start"

    invoke-static/range {v18 .. v19}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 32
    invoke-virtual/range {p2 .. p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v6

    .line 33
    .local v6, "bData":Landroid/os/Bundle;
    const-string v18, "msg"

    move-object/from16 v0, v18

    invoke-virtual {v6, v0}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v12

    .line 34
    .local v12, "msg":Ljava/lang/String;
    const-string v18, ""

    move-object/from16 v0, v18

    if-eq v12, v0, :cond_0

    if-nez v12, :cond_1

    .line 121
    :cond_0
    :goto_0
    return-void

    .line 36
    :cond_1
    const/4 v15, 0x0

    .line 38
    .local v15, "notificationIntent":Landroid/content/Intent;
    :try_start_0
    new-instance v15, Landroid/content/Intent;

    .end local v15    # "notificationIntent":Landroid/content/Intent;
    invoke-virtual/range {p0 .. p1}, Lcom/igg/iggsdkbusiness/LocalNotificationReceiver;->getLaunchActivity(Landroid/content/Context;)Ljava/lang/Class;

    move-result-object v18

    move-object/from16 v0, p1

    move-object/from16 v1, v18

    invoke-direct {v15, v0, v1}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V
    :try_end_0
    .catch Ljava/lang/ClassNotFoundException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/NullPointerException; {:try_start_0 .. :try_end_0} :catch_2

    .line 47
    .restart local v15    # "notificationIntent":Landroid/content/Intent;
    const/high16 v18, 0x24000000

    move/from16 v0, v18

    invoke-virtual {v15, v0}, Landroid/content/Intent;->setFlags(I)Landroid/content/Intent;

    .line 49
    const/16 v18, 0x0

    const/16 v19, 0x0

    move-object/from16 v0, p1

    move/from16 v1, v18

    move/from16 v2, v19

    invoke-static {v0, v1, v15, v2}, Landroid/app/PendingIntent;->getActivity(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v8

    .line 51
    .local v8, "call":Landroid/app/PendingIntent;
    const/16 v17, 0x0

    .line 53
    .local v17, "tmpSdkVersion":I
    :try_start_1
    sget v17, Landroid/os/Build$VERSION;->SDK_INT:I
    :try_end_1
    .catch Ljava/lang/NumberFormatException; {:try_start_1 .. :try_end_1} :catch_3

    .line 57
    :goto_1
    invoke-virtual/range {p1 .. p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v16

    .line 58
    .local v16, "res":Landroid/content/res/Resources;
    const-string v18, "app_icon"

    const-string v19, "drawable"

    invoke-virtual/range {p1 .. p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v20

    move-object/from16 v0, v16

    move-object/from16 v1, v18

    move-object/from16 v2, v19

    move-object/from16 v3, v20

    invoke-virtual {v0, v1, v2, v3}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v4

    .line 59
    .local v4, "LargeIcon":I
    const-string v18, "icon_status"

    const-string v19, "drawable"

    invoke-virtual/range {p1 .. p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v20

    move-object/from16 v0, v16

    move-object/from16 v1, v18

    move-object/from16 v2, v19

    move-object/from16 v3, v20

    invoke-virtual {v0, v1, v2, v3}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v5

    .line 60
    .local v5, "SmallIcon":I
    const/16 v18, 0x13

    move/from16 v0, v17

    move/from16 v1, v18

    if-le v0, v1, :cond_2

    .line 64
    move-object/from16 v0, v16

    invoke-static {v0, v4}, Landroid/graphics/BitmapFactory;->decodeResource(Landroid/content/res/Resources;I)Landroid/graphics/Bitmap;

    move-result-object v7

    .line 65
    .local v7, "bt":Landroid/graphics/Bitmap;
    new-instance v18, Landroid/app/Notification$Builder;

    move-object/from16 v0, v18

    move-object/from16 v1, p1

    invoke-direct {v0, v1}, Landroid/app/Notification$Builder;-><init>(Landroid/content/Context;)V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v20

    move-object/from16 v0, v18

    move-wide/from16 v1, v20

    invoke-virtual {v0, v1, v2}, Landroid/app/Notification$Builder;->setWhen(J)Landroid/app/Notification$Builder;

    move-result-object v18

    .line 66
    invoke-virtual/range {p0 .. p0}, Lcom/igg/iggsdkbusiness/LocalNotificationReceiver;->GetLocalTitle()Ljava/lang/String;

    move-result-object v19

    invoke-virtual/range {v18 .. v19}, Landroid/app/Notification$Builder;->setContentTitle(Ljava/lang/CharSequence;)Landroid/app/Notification$Builder;

    move-result-object v18

    .line 67
    move-object/from16 v0, v18

    invoke-virtual {v0, v12}, Landroid/app/Notification$Builder;->setContentText(Ljava/lang/CharSequence;)Landroid/app/Notification$Builder;

    move-result-object v18

    .line 68
    move-object/from16 v0, v18

    invoke-virtual {v0, v5}, Landroid/app/Notification$Builder;->setSmallIcon(I)Landroid/app/Notification$Builder;

    move-result-object v18

    .line 69
    move-object/from16 v0, v18

    invoke-virtual {v0, v7}, Landroid/app/Notification$Builder;->setLargeIcon(Landroid/graphics/Bitmap;)Landroid/app/Notification$Builder;

    move-result-object v18

    .line 70
    move-object/from16 v0, v18

    invoke-virtual {v0, v8}, Landroid/app/Notification$Builder;->setContentIntent(Landroid/app/PendingIntent;)Landroid/app/Notification$Builder;

    move-result-object v18

    .line 71
    invoke-virtual/range {v18 .. v18}, Landroid/app/Notification$Builder;->build()Landroid/app/Notification;

    move-result-object v14

    .line 101
    .end local v7    # "bt":Landroid/graphics/Bitmap;
    .local v14, "notification":Landroid/app/Notification;
    :goto_2
    iget v0, v14, Landroid/app/Notification;->flags:I

    move/from16 v18, v0

    or-int/lit8 v18, v18, 0x10

    move/from16 v0, v18

    iput v0, v14, Landroid/app/Notification;->flags:I

    .line 102
    iget v0, v14, Landroid/app/Notification;->defaults:I

    move/from16 v18, v0

    or-int/lit8 v18, v18, -0x1

    move/from16 v0, v18

    iput v0, v14, Landroid/app/Notification;->defaults:I

    .line 103
    iget v0, v14, Landroid/app/Notification;->defaults:I

    move/from16 v18, v0

    or-int/lit8 v18, v18, 0x1

    move/from16 v0, v18

    iput v0, v14, Landroid/app/Notification;->defaults:I

    .line 104
    const v18, -0xff0100

    move/from16 v0, v18

    iput v0, v14, Landroid/app/Notification;->ledARGB:I

    .line 107
    :try_start_2
    const-string v18, "Alarm"

    const-string v19, "onReceive - Start-6"

    invoke-static/range {v18 .. v19}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 108
    const-string v18, "notification"

    move-object/from16 v0, p1

    move-object/from16 v1, v18

    invoke-virtual {v0, v1}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v13

    check-cast v13, Landroid/app/NotificationManager;

    .line 109
    .local v13, "noMgr":Landroid/app/NotificationManager;
    const-string v18, "nid"

    move-object/from16 v0, v18

    invoke-virtual {v6, v0}, Landroid/os/Bundle;->getInt(Ljava/lang/String;)I

    move-result v18

    move/from16 v0, v18

    invoke-virtual {v13, v0, v14}, Landroid/app/NotificationManager;->notify(ILandroid/app/Notification;)V

    .line 111
    const-string v18, "Alarm"

    new-instance v19, Ljava/lang/StringBuilder;

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    const-string v20, "onReceive - bData.getInt(nid)"

    invoke-virtual/range {v19 .. v20}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v19

    const-string v20, "nid"

    move-object/from16 v0, v20

    invoke-virtual {v6, v0}, Landroid/os/Bundle;->getInt(Ljava/lang/String;)I

    move-result v20

    invoke-virtual/range {v19 .. v20}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v19

    invoke-virtual/range {v19 .. v19}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v19

    invoke-static/range {v18 .. v19}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_0

    goto/16 :goto_0

    .line 113
    .end local v13    # "noMgr":Landroid/app/NotificationManager;
    :catch_0
    move-exception v10

    .line 114
    .local v10, "e":Ljava/lang/Exception;
    const-string v18, "Alarm"

    new-instance v19, Ljava/lang/StringBuilder;

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    const-string v20, "Exception - "

    invoke-virtual/range {v19 .. v20}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v19

    invoke-virtual {v10}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v20

    invoke-virtual/range {v19 .. v20}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v19

    invoke-virtual/range {v19 .. v19}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v19

    invoke-static/range {v18 .. v19}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 39
    .end local v4    # "LargeIcon":I
    .end local v5    # "SmallIcon":I
    .end local v8    # "call":Landroid/app/PendingIntent;
    .end local v10    # "e":Ljava/lang/Exception;
    .end local v14    # "notification":Landroid/app/Notification;
    .end local v15    # "notificationIntent":Landroid/content/Intent;
    .end local v16    # "res":Landroid/content/res/Resources;
    .end local v17    # "tmpSdkVersion":I
    :catch_1
    move-exception v11

    .line 40
    .local v11, "e1":Ljava/lang/ClassNotFoundException;
    invoke-virtual {v11}, Ljava/lang/ClassNotFoundException;->printStackTrace()V

    goto/16 :goto_0

    .line 42
    .end local v11    # "e1":Ljava/lang/ClassNotFoundException;
    :catch_2
    move-exception v10

    .line 43
    .local v10, "e":Ljava/lang/NullPointerException;
    invoke-virtual {v10}, Ljava/lang/NullPointerException;->printStackTrace()V

    goto/16 :goto_0

    .line 54
    .end local v10    # "e":Ljava/lang/NullPointerException;
    .restart local v8    # "call":Landroid/app/PendingIntent;
    .restart local v15    # "notificationIntent":Landroid/content/Intent;
    .restart local v17    # "tmpSdkVersion":I
    :catch_3
    move-exception v10

    .line 55
    .local v10, "e":Ljava/lang/NumberFormatException;
    const/16 v17, 0x0

    goto/16 :goto_1

    .line 75
    .end local v10    # "e":Ljava/lang/NumberFormatException;
    .restart local v4    # "LargeIcon":I
    .restart local v5    # "SmallIcon":I
    .restart local v16    # "res":Landroid/content/res/Resources;
    :cond_2
    new-instance v14, Landroid/app/Notification;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v18

    move-wide/from16 v0, v18

    invoke-direct {v14, v4, v12, v0, v1}, Landroid/app/Notification;-><init>(ILjava/lang/CharSequence;J)V

    .line 78
    .restart local v14    # "notification":Landroid/app/Notification;
    const/4 v9, 0x0

    .line 80
    .local v9, "deprecatedMethod":Ljava/lang/reflect/Method;
    :try_start_3
    invoke-virtual {v14}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v18

    const-string v19, "setLatestEventInfo"

    const/16 v20, 0x4

    move/from16 v0, v20

    new-array v0, v0, [Ljava/lang/Class;

    move-object/from16 v20, v0

    const/16 v21, 0x0

    const-class v22, Landroid/content/Context;

    aput-object v22, v20, v21

    const/16 v21, 0x1

    const-class v22, Ljava/lang/CharSequence;

    aput-object v22, v20, v21

    const/16 v21, 0x2

    const-class v22, Ljava/lang/CharSequence;

    aput-object v22, v20, v21

    const/16 v21, 0x3

    const-class v22, Landroid/app/PendingIntent;

    aput-object v22, v20, v21

    invoke-virtual/range {v18 .. v20}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;
    :try_end_3
    .catch Ljava/lang/NoSuchMethodException; {:try_start_3 .. :try_end_3} :catch_5

    move-result-object v9

    .line 86
    :goto_3
    const/16 v18, 0x4

    :try_start_4
    move/from16 v0, v18

    new-array v0, v0, [Ljava/lang/Object;

    move-object/from16 v18, v0

    const/16 v19, 0x0

    aput-object p1, v18, v19

    const/16 v19, 0x1

    invoke-virtual/range {p0 .. p0}, Lcom/igg/iggsdkbusiness/LocalNotificationReceiver;->GetLocalTitle()Ljava/lang/String;

    move-result-object v20

    aput-object v20, v18, v19

    const/16 v19, 0x2

    aput-object v12, v18, v19

    const/16 v19, 0x3

    aput-object v8, v18, v19

    move-object/from16 v0, v18

    invoke-virtual {v9, v14, v0}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_4
    .catch Ljava/lang/IllegalAccessException; {:try_start_4 .. :try_end_4} :catch_4
    .catch Ljava/lang/IllegalArgumentException; {:try_start_4 .. :try_end_4} :catch_6
    .catch Ljava/lang/reflect/InvocationTargetException; {:try_start_4 .. :try_end_4} :catch_7

    goto/16 :goto_2

    .line 87
    :catch_4
    move-exception v10

    .line 89
    .local v10, "e":Ljava/lang/IllegalAccessException;
    invoke-virtual {v10}, Ljava/lang/IllegalAccessException;->printStackTrace()V

    .line 90
    const-string v18, "Alarm"

    invoke-virtual {v10}, Ljava/lang/IllegalAccessException;->toString()Ljava/lang/String;

    move-result-object v19

    invoke-static/range {v18 .. v19}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_2

    .line 81
    .end local v10    # "e":Ljava/lang/IllegalAccessException;
    :catch_5
    move-exception v10

    .line 83
    .local v10, "e":Ljava/lang/NoSuchMethodException;
    invoke-virtual {v10}, Ljava/lang/NoSuchMethodException;->printStackTrace()V

    goto :goto_3

    .line 91
    .end local v10    # "e":Ljava/lang/NoSuchMethodException;
    :catch_6
    move-exception v10

    .line 93
    .local v10, "e":Ljava/lang/IllegalArgumentException;
    invoke-virtual {v10}, Ljava/lang/IllegalArgumentException;->printStackTrace()V

    .line 94
    const-string v18, "Alarm"

    invoke-virtual {v10}, Ljava/lang/IllegalArgumentException;->toString()Ljava/lang/String;

    move-result-object v19

    invoke-static/range {v18 .. v19}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_2

    .line 95
    .end local v10    # "e":Ljava/lang/IllegalArgumentException;
    :catch_7
    move-exception v10

    .line 97
    .local v10, "e":Ljava/lang/reflect/InvocationTargetException;
    invoke-virtual {v10}, Ljava/lang/reflect/InvocationTargetException;->printStackTrace()V

    .line 98
    const-string v18, "Alarm"

    invoke-virtual {v10}, Ljava/lang/reflect/InvocationTargetException;->toString()Ljava/lang/String;

    move-result-object v19

    invoke-static/range {v18 .. v19}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_2
.end method
