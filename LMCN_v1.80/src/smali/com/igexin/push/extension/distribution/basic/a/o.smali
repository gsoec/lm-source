.class public Lcom/igexin/push/extension/distribution/basic/a/o;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/igexin/push/core/a/a/a;


# static fields
.field private static final a:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "EXT-"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-class v1, Lcom/igexin/push/extension/distribution/basic/a/o;

    invoke-virtual {v1}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/a/o;->a:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private a()I
    .locals 3

    const/4 v0, 0x0

    :try_start_0
    const-string v1, "com.android.internal.R$id"

    invoke-static {v1}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v1

    const-string v2, "icon"

    invoke-virtual {v1, v2}, Ljava/lang/Class;->getField(Ljava/lang/String;)Ljava/lang/reflect/Field;

    move-result-object v1

    const/4 v2, 0x1

    invoke-virtual {v1, v2}, Ljava/lang/reflect/Field;->setAccessible(Z)V

    const/4 v2, 0x0

    invoke-virtual {v1, v2}, Ljava/lang/reflect/Field;->getInt(Ljava/lang/Object;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result v0

    :goto_0
    return v0

    :catch_0
    move-exception v1

    goto :goto_0
.end method

.method private a(Lcom/igexin/push/extension/distribution/basic/b/m;Z)I
    .locals 6

    const v1, 0x1080093

    if-eqz p2, :cond_3

    sget-object v0, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    const-string v2, "push_small"

    const-string v3, "drawable"

    sget-object v4, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-virtual {v0, v2, v3, v4}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v0

    if-nez v0, :cond_0

    sget-object v0, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    const-string v2, "push_small"

    const-string v3, "mipmap"

    sget-object v4, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-virtual {v0, v2, v3, v4}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v0

    :cond_0
    if-eqz v0, :cond_2

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/a/o;->a:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "|push_small.png is set, use default push_small"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    move v1, v0

    :cond_1
    :goto_0
    return v1

    :cond_2
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/a/o;->a:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "|push_small.png is missing"

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    :cond_3
    sget-object v0, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    const-string v2, "push"

    const-string v3, "drawable"

    sget-object v4, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-virtual {v0, v2, v3, v4}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v0

    if-nez v0, :cond_4

    sget-object v0, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    const-string v2, "push"

    const-string v3, "mipmap"

    sget-object v4, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-virtual {v0, v2, v3, v4}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v0

    :cond_4
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/b/m;->p()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v2

    if-eqz v2, :cond_6

    if-eqz v0, :cond_5

    :goto_1
    move v1, v0

    goto :goto_0

    :cond_5
    move v0, v1

    goto :goto_1

    :cond_6
    const-string v2, "null"

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/b/m;->p()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_1

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/b/m;->p()Ljava/lang/String;

    move-result-object v2

    const-string v3, "@"

    invoke-virtual {v2, v3}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_7

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/b/m;->p()Ljava/lang/String;

    move-result-object v0

    const/4 v2, 0x1

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v3

    invoke-virtual {v0, v2, v3}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    const-string v2, "email"

    invoke-virtual {v0, v2}, Ljava/lang/String;->endsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    const v1, 0x108008f

    goto :goto_0

    :cond_7
    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v2}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v2

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/b/m;->p()Ljava/lang/String;

    move-result-object v3

    const-string v4, "drawable"

    sget-object v5, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-virtual {v2, v3, v4, v5}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v2

    if-nez v2, :cond_8

    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v2}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v2

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/b/m;->p()Ljava/lang/String;

    move-result-object v3

    const-string v4, "mipmap"

    sget-object v5, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-virtual {v2, v3, v4, v5}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v2

    :cond_8
    if-eqz v2, :cond_9

    move v1, v2

    goto/16 :goto_0

    :cond_9
    if-eqz v0, :cond_1

    move v1, v0

    goto/16 :goto_0
.end method

.method private a(Landroid/app/Notification;Lcom/igexin/push/extension/distribution/basic/b/m;)Landroid/app/Notification;
    .locals 2

    const/4 v1, 0x1

    const/4 v0, 0x4

    iput v0, p1, Landroid/app/Notification;->defaults:I

    const v0, -0xff0100

    iput v0, p1, Landroid/app/Notification;->ledARGB:I

    const/16 v0, 0x3e8

    iput v0, p1, Landroid/app/Notification;->ledOnMS:I

    const/16 v0, 0xbb8

    iput v0, p1, Landroid/app/Notification;->ledOffMS:I

    iput v1, p1, Landroid/app/Notification;->flags:I

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->o()Z

    move-result v0

    if-nez v0, :cond_0

    iget v0, p1, Landroid/app/Notification;->defaults:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p1, Landroid/app/Notification;->defaults:I

    :cond_0
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->m()Z

    move-result v0

    if-nez v0, :cond_2

    iget v0, p1, Landroid/app/Notification;->flags:I

    or-int/lit8 v0, v0, 0x10

    iput v0, p1, Landroid/app/Notification;->flags:I

    :goto_0
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->n()Z

    move-result v0

    if-nez v0, :cond_1

    iget v0, p1, Landroid/app/Notification;->defaults:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p1, Landroid/app/Notification;->defaults:I

    :cond_1
    invoke-direct {p0, p2, v1}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Lcom/igexin/push/extension/distribution/basic/b/m;Z)I

    move-result v0

    iput v0, p1, Landroid/app/Notification;->icon:I

    return-object p1

    :cond_2
    iget v0, p1, Landroid/app/Notification;->flags:I

    or-int/lit8 v0, v0, 0x20

    iput v0, p1, Landroid/app/Notification;->flags:I

    goto :goto_0
.end method

.method private a(Ljava/lang/String;Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/b/m;Z)Landroid/app/PendingIntent;
    .locals 6

    const/high16 v5, 0x8000000

    const/16 v4, 0x3e8

    new-instance v0, Landroid/content/Intent;

    const-string v1, "com.igexin.sdk.action.notification.burying.point"

    invoke-direct {v0, v1}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    const-string v1, "taskid"

    invoke-virtual {v0, v1, p1}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "messageid"

    invoke-virtual {v0, v1, p2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "appid"

    sget-object v2, Lcom/igexin/push/core/g;->a:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "actionid"

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->getDoActionId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "accesstoken"

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/c/j;->d:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "notifID"

    invoke-virtual {v0, v1, p3}, Landroid/content/Intent;->putExtra(Ljava/lang/String;I)Landroid/content/Intent;

    const-string v1, "notifyStyle"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "id"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->c()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "bigStyle"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "isFloat"

    invoke-virtual {v0, v1, p5}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Z)Landroid/content/Intent;

    const-string v1, "checkpackage"

    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v2}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "feedbackid"

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->getActionId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->getActionId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v3

    add-int/lit8 v3, v3, -0x1

    invoke-virtual {v2, v3}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v1, "2.10.3.1"

    const-string v2, "2.10.3.0"

    invoke-virtual {v1, v2}, Ljava/lang/String;->compareTo(Ljava/lang/String;)I

    move-result v1

    if-gez v1, :cond_0

    sget-object v1, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    new-instance v2, Ljava/util/Random;

    invoke-direct {v2}, Ljava/util/Random;-><init>()V

    invoke-virtual {v2, v4}, Ljava/util/Random;->nextInt(I)I

    move-result v2

    invoke-static {v1, v2, v0, v5}, Landroid/app/PendingIntent;->getBroadcast(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v0

    :goto_0
    return-object v0

    :cond_0
    :try_start_0
    new-instance v1, Landroid/content/Intent;

    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    sget-object v3, Lcom/igexin/push/extension/distribution/basic/c/j;->a:Landroid/content/Context;

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/util/i;->a(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v3

    invoke-direct {v1, v2, v3}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    const-string v2, "action"

    const-string v3, "com.igexin.action.notification.click"

    invoke-virtual {v1, v2, v3}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    const-string v2, "broadcast_intent"

    invoke-virtual {v1, v2, v0}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Landroid/os/Parcelable;)Landroid/content/Intent;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    sget-object v0, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    new-instance v2, Ljava/util/Random;

    invoke-direct {v2}, Ljava/util/Random;-><init>()V

    invoke-virtual {v2, v4}, Ljava/util/Random;->nextInt(I)I

    move-result v2

    invoke-static {v0, v2, v1, v5}, Landroid/app/PendingIntent;->getService(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v0

    goto :goto_0

    :catch_0
    move-exception v1

    sget-object v1, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    new-instance v2, Ljava/util/Random;

    invoke-direct {v2}, Ljava/util/Random;-><init>()V

    invoke-virtual {v2, v4}, Ljava/util/Random;->nextInt(I)I

    move-result v2

    invoke-static {v1, v2, v0, v5}, Landroid/app/PendingIntent;->getBroadcast(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v0

    goto :goto_0
.end method

.method private b(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/b/m;I)V
    .locals 15

    const/4 v1, 0x1

    move-object/from16 v0, p3

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Lcom/igexin/push/extension/distribution/basic/b/m;Z)I

    move-result v7

    const/4 v1, 0x0

    move-object/from16 v0, p3

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Lcom/igexin/push/extension/distribution/basic/b/m;Z)I

    move-result v8

    sget-object v1, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static {v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/k/l;

    move-result-object v1

    const-string v2, "getui_notification"

    const-string v3, "layout"

    invoke-virtual {v1, v2, v3}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v2

    if-eqz v2, :cond_0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/a/o;->d()Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->b()Z

    move-result v2

    if-eqz v2, :cond_1

    :cond_0
    :goto_0
    return-void

    :cond_1
    const-string v2, "getui_notification_bg"

    const-string v3, "id"

    invoke-virtual {v1, v2, v3}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v2

    const-string v3, "getui_notification_icon"

    const-string v4, "id"

    invoke-virtual {v1, v3, v4}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    const-string v4, "getui_notification_date"

    const-string v5, "id"

    invoke-virtual {v1, v4, v5}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v4

    const-string v5, "getui_notification_icon2"

    const-string v6, "id"

    invoke-virtual {v1, v5, v6}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v5

    const-string v6, "getui_notification_headsup"

    const-string v9, "id"

    invoke-virtual {v1, v6, v9}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v6

    const-string v9, "getui_icon_headsup"

    const-string v10, "id"

    invoke-virtual {v1, v9, v10}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v9

    const-string v10, "getui_title_headsup"

    const-string v11, "id"

    invoke-virtual {v1, v10, v11}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v10

    const-string v11, "getui_time_headsup"

    const-string v12, "id"

    invoke-virtual {v1, v11, v12}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v11

    const-string v12, "getui_message_headsup"

    const-string v13, "id"

    invoke-virtual {v1, v12, v13}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v12

    const-string v13, "getui_headsup_banner"

    const-string v14, "id"

    invoke-virtual {v1, v13, v14}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v1

    if-eqz v2, :cond_0

    if-eqz v3, :cond_0

    if-eqz v4, :cond_0

    if-eqz v5, :cond_0

    if-eqz v6, :cond_0

    if-eqz v9, :cond_0

    if-eqz v10, :cond_0

    if-eqz v11, :cond_0

    if-eqz v12, :cond_0

    if-eqz v1, :cond_0

    const/4 v6, 0x1

    move-object v1, p0

    move-object/from16 v2, p1

    move-object/from16 v3, p2

    move/from16 v4, p4

    move-object/from16 v5, p3

    invoke-direct/range {v1 .. v6}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Ljava/lang/String;Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/b/m;Z)Landroid/app/PendingIntent;

    move-result-object v1

    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static {v2}, Lcom/igexin/push/extension/distribution/basic/headsup/m;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/headsup/m;

    move-result-object v2

    new-instance v3, Lcom/igexin/push/extension/distribution/basic/headsup/l;

    sget-object v4, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-direct {v3, v4}, Lcom/igexin/push/extension/distribution/basic/headsup/l;-><init>(Landroid/content/Context;)V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->k()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Ljava/lang/CharSequence;)Lcom/igexin/push/extension/distribution/basic/headsup/l;

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->g()Ljava/lang/String;

    move-result-object v4

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->t()Ljava/lang/String;

    move-result-object v5

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->s()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v7}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(I)Lcom/igexin/push/extension/distribution/basic/headsup/l;

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Landroid/app/PendingIntent;)Lcom/igexin/push/extension/distribution/basic/headsup/l;

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->l()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->b(Ljava/lang/CharSequence;)Lcom/igexin/push/extension/distribution/basic/headsup/l;

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->C()Z

    move-result v1

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->b(Z)V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v1

    const/4 v7, 0x4

    if-ne v1, v7, :cond_3

    if-eqz v5, :cond_0

    const-string v1, ""

    invoke-virtual {v5, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_0

    invoke-static {v5}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v1

    if-eqz v1, :cond_0

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->b(Landroid/graphics/Bitmap;)V

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/c/b;->d:Lcom/igexin/push/extension/distribution/basic/c/b;

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Lcom/igexin/push/extension/distribution/basic/c/b;)V

    :cond_2
    :goto_1
    sget-object v1, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static {v1}, Lcom/igexin/push/extension/distribution/basic/headsup/m;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/headsup/m;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/headsup/m;->a()V

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a()Lcom/igexin/push/extension/distribution/basic/headsup/j;

    move-result-object v1

    const/4 v3, 0x0

    invoke-virtual {v1, v3}, Lcom/igexin/push/extension/distribution/basic/headsup/j;->c(Z)V

    move/from16 v0, p4

    invoke-virtual {v2, v0, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/m;->a(ILcom/igexin/push/extension/distribution/basic/headsup/j;)V

    goto/16 :goto_0

    :cond_3
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v1

    const/4 v7, 0x6

    if-ne v1, v7, :cond_c

    if-eqz v6, :cond_6

    const-string v1, ""

    invoke-virtual {v1, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_6

    invoke-static {v6}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v1

    if-eqz v1, :cond_4

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->c(Landroid/graphics/Bitmap;)V

    :cond_4
    :goto_2
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v1

    const/4 v6, 0x1

    if-ne v1, v6, :cond_7

    if-eqz v4, :cond_5

    const-string v1, ""

    invoke-virtual {v1, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_5

    invoke-static {v4}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v1

    if-eqz v1, :cond_5

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Landroid/graphics/Bitmap;)V

    :cond_5
    sget-object v1, Lcom/igexin/push/extension/distribution/basic/c/b;->a:Lcom/igexin/push/extension/distribution/basic/c/b;

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Lcom/igexin/push/extension/distribution/basic/c/b;)V

    goto :goto_1

    :cond_6
    sget-object v1, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v1

    invoke-static {v1, v8}, Landroid/graphics/BitmapFactory;->decodeResource(Landroid/content/res/Resources;I)Landroid/graphics/Bitmap;

    move-result-object v1

    if-eqz v1, :cond_4

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->c(Landroid/graphics/Bitmap;)V

    goto :goto_2

    :cond_7
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v1

    const/4 v6, 0x2

    if-ne v1, v6, :cond_9

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_2

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v1

    const-string v4, ""

    invoke-virtual {v1, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/String;->length()I

    move-result v1

    const/16 v4, 0x64

    if-le v1, v4, :cond_8

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v4

    const/4 v5, 0x0

    const/16 v6, 0x64

    invoke-virtual {v4, v5, v6}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v4, "..."

    invoke-virtual {v1, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Ljava/lang/String;)V

    :goto_3
    sget-object v1, Lcom/igexin/push/extension/distribution/basic/c/b;->b:Lcom/igexin/push/extension/distribution/basic/c/b;

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Lcom/igexin/push/extension/distribution/basic/c/b;)V

    goto/16 :goto_1

    :cond_8
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Ljava/lang/String;)V

    goto :goto_3

    :cond_9
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v1

    const/4 v6, 0x3

    if-ne v1, v6, :cond_2

    if-eqz v4, :cond_a

    const-string v1, ""

    invoke-virtual {v1, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_a

    invoke-static {v4}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v1

    if-eqz v1, :cond_a

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Landroid/graphics/Bitmap;)V

    :cond_a
    if-eqz v5, :cond_b

    const-string v1, ""

    invoke-virtual {v5, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_b

    invoke-static {v5}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v1

    if-eqz v1, :cond_b

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->b(Landroid/graphics/Bitmap;)V

    :cond_b
    sget-object v1, Lcom/igexin/push/extension/distribution/basic/c/b;->c:Lcom/igexin/push/extension/distribution/basic/c/b;

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Lcom/igexin/push/extension/distribution/basic/c/b;)V

    goto/16 :goto_1

    :cond_c
    sget-object v1, Lcom/igexin/push/extension/distribution/basic/c/b;->e:Lcom/igexin/push/extension/distribution/basic/c/b;

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->a(Lcom/igexin/push/extension/distribution/basic/c/b;)V

    if-eqz v6, :cond_d

    const-string v1, ""

    invoke-virtual {v1, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_d

    invoke-static {v6}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v1

    if-eqz v1, :cond_2

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->c(Landroid/graphics/Bitmap;)V

    goto/16 :goto_1

    :cond_d
    sget-object v1, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v1

    invoke-static {v1, v8}, Landroid/graphics/BitmapFactory;->decodeResource(Landroid/content/res/Resources;I)Landroid/graphics/Bitmap;

    move-result-object v1

    if-eqz v1, :cond_2

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/headsup/l;->c(Landroid/graphics/Bitmap;)V

    goto/16 :goto_1
.end method

.method private b()Z
    .locals 4

    const/4 v1, 0x1

    const/4 v0, 0x0

    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v2}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v2

    invoke-virtual {v2}, Landroid/content/res/Resources;->getConfiguration()Landroid/content/res/Configuration;

    move-result-object v2

    iget v2, v2, Landroid/content/res/Configuration;->orientation:I

    const/4 v3, 0x2

    if-ne v2, v3, :cond_1

    :cond_0
    :goto_0
    return v0

    :cond_1
    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v2}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v2

    invoke-virtual {v2}, Landroid/content/res/Resources;->getConfiguration()Landroid/content/res/Configuration;

    move-result-object v2

    iget v2, v2, Landroid/content/res/Configuration;->orientation:I

    if-ne v2, v1, :cond_0

    move v0, v1

    goto :goto_0
.end method

.method private c(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/b/m;I)V
    .locals 31
    .annotation build Landroid/annotation/TargetApi;
        value = 0x10
    .end annotation

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->b()Z

    move-result v3

    if-eqz v3, :cond_1

    :cond_0
    :goto_0
    return-void

    :cond_1
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->g()Ljava/lang/String;

    move-result-object v9

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->t()Ljava/lang/String;

    move-result-object v10

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->s()Ljava/lang/String;

    move-result-object v11

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->D()Ljava/lang/String;

    move-result-object v12

    sget-object v3, Lcom/igexin/push/core/g;->ai:Ljava/util/Map;

    invoke-static/range {p4 .. p4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    move-object/from16 v0, p1

    invoke-interface {v3, v0, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const/4 v8, 0x0

    move-object/from16 v3, p0

    move-object/from16 v4, p1

    move-object/from16 v5, p2

    move/from16 v6, p4

    move-object/from16 v7, p3

    invoke-direct/range {v3 .. v8}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Ljava/lang/String;Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/b/m;Z)Landroid/app/PendingIntent;

    move-result-object v6

    sget-object v3, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    const-string v4, "notification"

    invoke-virtual {v3, v4}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroid/app/NotificationManager;

    new-instance v7, Landroid/support/v4/app/NotificationCompat$Builder;

    sget-object v4, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-direct {v7, v4}, Landroid/support/v4/app/NotificationCompat$Builder;-><init>(Landroid/content/Context;)V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->l()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v7, v4}, Landroid/support/v4/app/NotificationCompat$Builder;->setContentText(Ljava/lang/CharSequence;)Landroid/support/v4/app/NotificationCompat$Builder;

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->k()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v7, v4}, Landroid/support/v4/app/NotificationCompat$Builder;->setContentTitle(Ljava/lang/CharSequence;)Landroid/support/v4/app/NotificationCompat$Builder;

    const/4 v5, 0x0

    const/4 v4, 0x0

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v8

    const/4 v13, 0x1

    if-eq v8, v13, :cond_2

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v8

    const/4 v13, 0x2

    if-ne v8, v13, :cond_12

    :cond_2
    sget-object v4, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static {v4}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/k/l;

    move-result-object v8

    const-string v4, "getui_notification"

    const-string v5, "layout"

    invoke-virtual {v8, v4, v5}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v10

    new-instance v5, Landroid/widget/RemoteViews;

    sget-object v4, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-direct {v5, v4, v10}, Landroid/widget/RemoteViews;-><init>(Ljava/lang/String;I)V

    new-instance v4, Landroid/widget/RemoteViews;

    sget-object v13, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-direct {v4, v13, v10}, Landroid/widget/RemoteViews;-><init>(Ljava/lang/String;I)V

    invoke-static {v10}, Lcom/igexin/push/extension/distribution/basic/util/c;->a(I)Z

    move-result v13

    if-eqz v10, :cond_0

    const-string v10, "getui_big_default_Content"

    const-string v14, "id"

    invoke-virtual {v8, v10, v14}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v10

    const-string v14, "getui_big_bigview_defaultView"

    const-string v15, "id"

    invoke-virtual {v8, v14, v15}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v14

    const-string v15, "getui_big_bigtext_defaultView"

    const-string v16, "id"

    move-object/from16 v0, v16

    invoke-virtual {v8, v15, v0}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v15

    const-string v16, "getui_big_notification_icon"

    const-string v17, "id"

    move-object/from16 v0, v16

    move-object/from16 v1, v17

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v16

    const-string v17, "getui_big_notification_date"

    const-string v18, "id"

    move-object/from16 v0, v17

    move-object/from16 v1, v18

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v17

    const-string v18, "getui_big_notification_icon2"

    const-string v19, "id"

    move-object/from16 v0, v18

    move-object/from16 v1, v19

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v18

    const-string v19, "getui_big_notification_title"

    const-string v20, "id"

    move-object/from16 v0, v19

    move-object/from16 v1, v20

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v19

    const-string v20, "getui_big_notification_content"

    const-string v21, "id"

    move-object/from16 v0, v20

    move-object/from16 v1, v21

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v20

    const-string v21, "getui_big_notification_title_center"

    const-string v22, "id"

    move-object/from16 v0, v21

    move-object/from16 v1, v22

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v21

    const-string v22, "getui_notification_bg"

    const-string v23, "id"

    move-object/from16 v0, v22

    move-object/from16 v1, v23

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v22

    const-string v23, "getui_notification_icon"

    const-string v24, "id"

    move-object/from16 v0, v23

    move-object/from16 v1, v24

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v23

    const-string v24, "getui_notification_date"

    const-string v25, "id"

    move-object/from16 v0, v24

    move-object/from16 v1, v25

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v24

    const-string v25, "getui_notification_icon2"

    const-string v26, "id"

    move-object/from16 v0, v25

    move-object/from16 v1, v26

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v25

    const-string v26, "getui_notification_style1"

    const-string v27, "id"

    move-object/from16 v0, v26

    move-object/from16 v1, v27

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v26

    const-string v27, "getui_notification_style1_title"

    const-string v28, "id"

    move-object/from16 v0, v27

    move-object/from16 v1, v28

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v27

    const-string v28, "getui_notification_style1_content"

    const-string v29, "id"

    move-object/from16 v0, v28

    move-object/from16 v1, v29

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v8

    if-eqz v10, :cond_0

    if-eqz v14, :cond_0

    if-eqz v15, :cond_0

    if-eqz v16, :cond_0

    if-eqz v17, :cond_0

    if-eqz v18, :cond_0

    if-eqz v19, :cond_0

    if-eqz v20, :cond_0

    if-eqz v21, :cond_0

    if-eqz v22, :cond_0

    if-eqz v23, :cond_0

    if-eqz v24, :cond_0

    if-eqz v25, :cond_0

    if-eqz v26, :cond_0

    if-eqz v27, :cond_0

    if-eqz v8, :cond_0

    if-eqz v13, :cond_3

    :try_start_0
    sget-object v28, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/util/o;

    move-result-object v28

    const/16 v29, 0x0

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->f()F

    move-result v30

    move/from16 v0, v17

    move/from16 v1, v29

    move/from16 v2, v30

    invoke-virtual {v5, v0, v1, v2}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    const/16 v29, 0x0

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->d()F

    move-result v30

    move/from16 v0, v21

    move/from16 v1, v29

    move/from16 v2, v30

    invoke-virtual {v5, v0, v1, v2}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    const/16 v29, 0x0

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->d()F

    move-result v30

    move/from16 v0, v19

    move/from16 v1, v29

    move/from16 v2, v30

    invoke-virtual {v5, v0, v1, v2}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    const/16 v29, 0x0

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->e()F

    move-result v30

    move/from16 v0, v29

    move/from16 v1, v30

    invoke-virtual {v5, v15, v0, v1}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    const/16 v29, 0x0

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->e()F

    move-result v30

    move/from16 v0, v20

    move/from16 v1, v29

    move/from16 v2, v30

    invoke-virtual {v5, v0, v1, v2}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    const/16 v29, 0x0

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->f()F

    move-result v30

    move/from16 v0, v24

    move/from16 v1, v29

    move/from16 v2, v30

    invoke-virtual {v4, v0, v1, v2}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    const/16 v29, 0x0

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->d()F

    move-result v30

    move/from16 v0, v27

    move/from16 v1, v29

    move/from16 v2, v30

    invoke-virtual {v4, v0, v1, v2}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    const/16 v29, 0x0

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->e()F

    move-result v30

    move/from16 v0, v29

    move/from16 v1, v30

    invoke-virtual {v4, v8, v0, v1}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->c()I

    move-result v29

    move/from16 v0, v17

    move/from16 v1, v29

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextColor(II)V

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->a()I

    move-result v29

    move/from16 v0, v21

    move/from16 v1, v29

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextColor(II)V

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->a()I

    move-result v29

    move/from16 v0, v19

    move/from16 v1, v29

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextColor(II)V

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->b()I

    move-result v29

    move/from16 v0, v29

    invoke-virtual {v5, v15, v0}, Landroid/widget/RemoteViews;->setTextColor(II)V

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->b()I

    move-result v29

    move/from16 v0, v20

    move/from16 v1, v29

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextColor(II)V

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->c()I

    move-result v29

    move/from16 v0, v24

    move/from16 v1, v29

    invoke-virtual {v4, v0, v1}, Landroid/widget/RemoteViews;->setTextColor(II)V

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->a()I

    move-result v29

    move/from16 v0, v27

    move/from16 v1, v29

    invoke-virtual {v4, v0, v1}, Landroid/widget/RemoteViews;->setTextColor(II)V

    invoke-virtual/range {v28 .. v28}, Lcom/igexin/push/extension/distribution/basic/util/o;->b()I

    move-result v28

    move/from16 v0, v28

    invoke-virtual {v4, v8, v0}, Landroid/widget/RemoteViews;->setTextColor(II)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :cond_3
    :goto_1
    const/16 v28, 0x8

    move/from16 v0, v22

    move/from16 v1, v28

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v28, 0x8

    move/from16 v0, v23

    move/from16 v1, v28

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v28, 0x8

    move/from16 v0, v24

    move/from16 v1, v28

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v28, 0x8

    move/from16 v0, v25

    move/from16 v1, v28

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v28, 0x0

    move/from16 v0, v28

    invoke-virtual {v5, v10, v0}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v28

    const/16 v29, 0x1

    move/from16 v0, v28

    move/from16 v1, v29

    if-ne v0, v1, :cond_d

    const/16 v28, 0x8

    move/from16 v0, v21

    move/from16 v1, v28

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    :cond_4
    :goto_2
    const/16 v21, 0x0

    move/from16 v0, v26

    move/from16 v1, v21

    invoke-virtual {v4, v0, v1}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v21, 0x8

    move/from16 v0, v22

    move/from16 v1, v21

    invoke-virtual {v4, v0, v1}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->l()Ljava/lang/String;

    move-result-object v21

    move/from16 v0, v20

    move-object/from16 v1, v21

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->C()Z

    move-result v20

    if-eqz v20, :cond_5

    new-instance v20, Ljava/text/SimpleDateFormat;

    const-string v21, "HH:mm"

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v22

    invoke-direct/range {v20 .. v22}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    new-instance v21, Ljava/util/Date;

    invoke-direct/range {v21 .. v21}, Ljava/util/Date;-><init>()V

    invoke-virtual/range {v20 .. v21}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v20

    move/from16 v0, v17

    move-object/from16 v1, v20

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    move/from16 v0, v24

    move-object/from16 v1, v20

    invoke-virtual {v4, v0, v1}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    :cond_5
    if-nez v13, :cond_6

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->a()Z

    move-result v17

    if-eqz v17, :cond_6

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->b()Z

    move-result v17

    if-eqz v17, :cond_6

    const/16 v17, 0x20

    const/16 v20, 0x20

    const/16 v21, 0x20

    move/from16 v0, v17

    move/from16 v1, v20

    move/from16 v2, v21

    invoke-static {v0, v1, v2}, Landroid/graphics/Color;->rgb(III)I

    move-result v17

    move/from16 v0, v27

    move/from16 v1, v17

    invoke-virtual {v4, v0, v1}, Landroid/widget/RemoteViews;->setTextColor(II)V

    move/from16 v0, v19

    move/from16 v1, v17

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextColor(II)V

    :cond_6
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->k()Ljava/lang/String;

    move-result-object v17

    move/from16 v0, v19

    move-object/from16 v1, v17

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->k()Ljava/lang/String;

    move-result-object v17

    move/from16 v0, v27

    move-object/from16 v1, v17

    invoke-virtual {v4, v0, v1}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->l()Ljava/lang/String;

    move-result-object v17

    move-object/from16 v0, v17

    invoke-virtual {v4, v8, v0}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    if-eqz v9, :cond_7

    const-string v8, ""

    invoke-virtual {v8, v9}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-nez v8, :cond_7

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v8

    const/16 v17, 0x1

    move/from16 v0, v17

    if-ne v8, v0, :cond_7

    invoke-static {v9}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v8

    if-eqz v8, :cond_7

    const/4 v9, 0x0

    invoke-virtual {v5, v14, v9}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    invoke-virtual {v5, v14, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    :cond_7
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v8

    if-eqz v8, :cond_9

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v8

    const-string v9, ""

    invoke-virtual {v8, v9}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-nez v8, :cond_9

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v8

    const/4 v9, 0x2

    if-ne v8, v9, :cond_9

    const/4 v8, 0x0

    invoke-virtual {v5, v15, v8}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    if-nez v13, :cond_8

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->a()Z

    move-result v8

    if-eqz v8, :cond_8

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->b()Z

    move-result v8

    if-eqz v8, :cond_8

    const/16 v8, 0x99

    const/16 v9, 0x99

    const/16 v13, 0x99

    invoke-static {v8, v9, v13}, Landroid/graphics/Color;->rgb(III)I

    move-result v8

    invoke-virtual {v5, v15, v8}, Landroid/widget/RemoteViews;->setTextColor(II)V

    :cond_8
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/String;->length()I

    move-result v8

    const/16 v9, 0x64

    if-le v8, v9, :cond_f

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v9

    const/4 v13, 0x0

    const/16 v14, 0x64

    invoke-virtual {v9, v13, v14}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "...\n"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v5, v15, v8}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    :cond_9
    :goto_3
    if-eqz v11, :cond_10

    const-string v8, ""

    invoke-virtual {v11, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-nez v8, :cond_10

    invoke-static {v11}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v8

    if-eqz v8, :cond_a

    move/from16 v0, v23

    invoke-virtual {v4, v0, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    move/from16 v0, v16

    invoke-virtual {v5, v0, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    :cond_a
    :goto_4
    if-eqz v12, :cond_11

    invoke-static {v12}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v8

    if-eqz v8, :cond_b

    move/from16 v0, v18

    invoke-virtual {v5, v0, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    move/from16 v0, v25

    invoke-virtual {v4, v0, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    :cond_b
    :goto_5
    invoke-virtual {v5, v10, v6}, Landroid/widget/RemoteViews;->setOnClickPendingIntent(ILandroid/app/PendingIntent;)V

    move/from16 v0, v26

    invoke-virtual {v4, v0, v6}, Landroid/widget/RemoteViews;->setOnClickPendingIntent(ILandroid/app/PendingIntent;)V

    :cond_c
    :goto_6
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->a()I

    move-result v6

    invoke-virtual {v7, v6}, Landroid/support/v4/app/NotificationCompat$Builder;->setPriority(I)Landroid/support/v4/app/NotificationCompat$Builder;

    invoke-virtual {v7}, Landroid/support/v4/app/NotificationCompat$Builder;->build()Landroid/app/Notification;

    move-result-object v6

    move-object/from16 v0, p0

    move-object/from16 v1, p3

    invoke-direct {v0, v6, v1}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Landroid/app/Notification;Lcom/igexin/push/extension/distribution/basic/b/m;)Landroid/app/Notification;

    move-result-object v6

    iput-object v5, v6, Landroid/app/Notification;->bigContentView:Landroid/widget/RemoteViews;

    iput-object v4, v6, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    move/from16 v0, p4

    invoke-static {v3, v0, v6}, Lcom/igexin/push/extension/distribution/basic/util/p;->a(Landroid/app/NotificationManager;ILandroid/app/Notification;)V

    goto/16 :goto_0

    :cond_d
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v28

    const/16 v29, 0x2

    move/from16 v0, v28

    move/from16 v1, v29

    if-ne v0, v1, :cond_4

    const/16 v28, 0x8

    move/from16 v0, v19

    move/from16 v1, v28

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v28, 0x8

    move/from16 v0, v20

    move/from16 v1, v28

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    if-nez v13, :cond_e

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->a()Z

    move-result v28

    if-eqz v28, :cond_e

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->b()Z

    move-result v28

    if-eqz v28, :cond_e

    const/16 v28, 0x20

    const/16 v29, 0x20

    const/16 v30, 0x20

    invoke-static/range {v28 .. v30}, Landroid/graphics/Color;->rgb(III)I

    move-result v28

    move/from16 v0, v21

    move/from16 v1, v28

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextColor(II)V

    :cond_e
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->k()Ljava/lang/String;

    move-result-object v28

    move/from16 v0, v21

    move-object/from16 v1, v28

    invoke-virtual {v5, v0, v1}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    goto/16 :goto_2

    :cond_f
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->e()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "\n"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v5, v15, v8}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    goto/16 :goto_3

    :cond_10
    sget-object v8, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v8}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v8

    const/4 v9, 0x0

    move-object/from16 v0, p0

    move-object/from16 v1, p3

    invoke-direct {v0, v1, v9}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Lcom/igexin/push/extension/distribution/basic/b/m;Z)I

    move-result v9

    invoke-static {v8, v9}, Landroid/graphics/BitmapFactory;->decodeResource(Landroid/content/res/Resources;I)Landroid/graphics/Bitmap;

    move-result-object v8

    if-eqz v8, :cond_a

    move/from16 v0, v23

    invoke-virtual {v4, v0, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    move/from16 v0, v16

    invoke-virtual {v5, v0, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    goto/16 :goto_4

    :cond_11
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->z()Ljava/lang/String;

    move-result-object v8

    if-eqz v8, :cond_b

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->z()Ljava/lang/String;

    move-result-object v8

    const-string v9, "@package:"

    invoke-virtual {v8, v9}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v8

    if-eqz v8, :cond_b

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->z()Ljava/lang/String;

    move-result-object v8

    const/16 v9, 0x9

    invoke-virtual {v8, v9}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v8

    invoke-static {v8}, Lcom/igexin/push/extension/distribution/basic/util/m;->a(Ljava/lang/String;)Landroid/graphics/drawable/Drawable;

    move-result-object v8

    if-eqz v8, :cond_b

    invoke-static {v8}, Lcom/igexin/push/extension/distribution/basic/util/m;->a(Landroid/graphics/drawable/Drawable;)Landroid/graphics/Bitmap;

    move-result-object v8

    if-eqz v8, :cond_b

    move/from16 v0, v18

    invoke-virtual {v5, v0, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    move/from16 v0, v25

    invoke-virtual {v4, v0, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    goto/16 :goto_5

    :cond_12
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v8

    const/4 v11, 0x3

    if-ne v8, v11, :cond_c

    sget-object v4, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static {v4}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/k/l;

    move-result-object v8

    const-string v4, "getui_notification"

    const-string v5, "layout"

    invoke-virtual {v8, v4, v5}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v11

    new-instance v5, Landroid/widget/RemoteViews;

    sget-object v4, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-direct {v5, v4, v11}, Landroid/widget/RemoteViews;-><init>(Ljava/lang/String;I)V

    new-instance v4, Landroid/widget/RemoteViews;

    sget-object v12, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-direct {v4, v12, v11}, Landroid/widget/RemoteViews;-><init>(Ljava/lang/String;I)V

    if-eqz v11, :cond_0

    const-string v11, "getui_bigview_banner"

    const-string v12, "id"

    invoke-virtual {v8, v11, v12}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v11

    const-string v12, "getui_bigview_expanded"

    const-string v13, "id"

    invoke-virtual {v8, v12, v13}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v12

    const-string v13, "getui_notification_bg"

    const-string v14, "id"

    invoke-virtual {v8, v13, v14}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v13

    const-string v14, "getui_notification_icon"

    const-string v15, "id"

    invoke-virtual {v8, v14, v15}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v14

    const-string v15, "getui_notification_date"

    const-string v16, "id"

    move-object/from16 v0, v16

    invoke-virtual {v8, v15, v0}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v15

    const-string v16, "getui_notification_icon2"

    const-string v17, "id"

    move-object/from16 v0, v16

    move-object/from16 v1, v17

    invoke-virtual {v8, v0, v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v8

    if-eqz v11, :cond_0

    if-eqz v12, :cond_0

    if-eqz v13, :cond_0

    if-eqz v14, :cond_0

    if-eqz v15, :cond_0

    if-eqz v8, :cond_0

    const/16 v16, 0x8

    move/from16 v0, v16

    invoke-virtual {v5, v13, v0}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v16, 0x8

    move/from16 v0, v16

    invoke-virtual {v5, v14, v0}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v16, 0x8

    move/from16 v0, v16

    invoke-virtual {v5, v15, v0}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v16, 0x8

    move/from16 v0, v16

    invoke-virtual {v5, v8, v0}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v16, 0x8

    move/from16 v0, v16

    invoke-virtual {v4, v13, v0}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v13, 0x8

    invoke-virtual {v4, v14, v13}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v13, 0x8

    invoke-virtual {v4, v15, v13}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    const/16 v13, 0x8

    invoke-virtual {v4, v8, v13}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    if-eqz v9, :cond_13

    const-string v8, ""

    invoke-virtual {v8, v9}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-nez v8, :cond_13

    invoke-static {v9}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v8

    if-eqz v8, :cond_13

    const/4 v9, 0x0

    invoke-virtual {v5, v12, v9}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    invoke-virtual {v5, v12, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    :cond_13
    if-eqz v10, :cond_14

    const-string v8, ""

    invoke-virtual {v8, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-nez v8, :cond_14

    invoke-static {v10}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v8

    if-eqz v8, :cond_14

    const/4 v9, 0x0

    invoke-virtual {v4, v11, v9}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    invoke-virtual {v4, v11, v8}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    :cond_14
    invoke-virtual {v5, v12, v6}, Landroid/widget/RemoteViews;->setOnClickPendingIntent(ILandroid/app/PendingIntent;)V

    invoke-virtual {v4, v11, v6}, Landroid/widget/RemoteViews;->setOnClickPendingIntent(ILandroid/app/PendingIntent;)V

    goto/16 :goto_6

    :catch_0
    move-exception v28

    goto/16 :goto_1
.end method

.method private c()Z
    .locals 2

    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x10

    if-lt v0, v1, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private d()Z
    .locals 3

    sget-object v0, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v0

    const-string v1, "android.permission.SYSTEM_ALERT_WINDOW"

    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v2}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/pm/PackageManager;->checkPermission(Ljava/lang/String;Ljava/lang/String;)I

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method


# virtual methods
.method public a(Lcom/igexin/push/core/bean/PushTaskBean;Lcom/igexin/push/core/bean/BaseAction;)Lcom/igexin/push/core/b;
    .locals 13

    instance-of v0, p2, Lcom/igexin/push/extension/distribution/basic/b/m;

    if-eqz v0, :cond_e

    move-object v0, p2

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/m;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/b/m;->q()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/b/m;->r()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/b/m;->z()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/b/m;->j()Ljava/lang/String;

    move-result-object v12

    invoke-virtual {p1}, Lcom/igexin/push/core/bean/PushTaskBean;->getTaskId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p1}, Lcom/igexin/push/core/bean/PushTaskBean;->getMessageId()Ljava/lang/String;

    move-result-object v3

    const/4 v6, 0x0

    const/4 v5, 0x0

    const/4 v4, 0x0

    const/4 v7, 0x0

    if-eqz v12, :cond_6

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/c/g;->a()Lcom/igexin/push/extension/distribution/basic/c/g;

    move-result-object v8

    invoke-virtual {v8, v12}, Lcom/igexin/push/extension/distribution/basic/c/g;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    const-string v9, ""

    invoke-virtual {v8, v9}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v9

    if-eqz v9, :cond_5

    const/4 v7, 0x1

    const/4 v8, 0x0

    invoke-virtual {v0, v8}, Lcom/igexin/push/extension/distribution/basic/b/m;->c(Z)V

    move v9, v7

    :goto_0
    if-eqz v1, :cond_8

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/c/g;->a()Lcom/igexin/push/extension/distribution/basic/c/g;

    move-result-object v7

    invoke-virtual {v7, v1}, Lcom/igexin/push/extension/distribution/basic/c/g;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    const-string v8, ""

    invoke-virtual {v7, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_7

    const/4 v6, 0x1

    const/4 v7, 0x0

    invoke-virtual {v0, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->g(Z)V

    move v8, v6

    :goto_1
    if-eqz v10, :cond_a

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/c/g;->a()Lcom/igexin/push/extension/distribution/basic/c/g;

    move-result-object v6

    invoke-virtual {v6, v10}, Lcom/igexin/push/extension/distribution/basic/c/g;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    const-string v7, ""

    invoke-virtual {v6, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_9

    const/4 v5, 0x1

    const/4 v6, 0x0

    invoke-virtual {v0, v6}, Lcom/igexin/push/extension/distribution/basic/b/m;->h(Z)V

    move v7, v5

    :goto_2
    if-eqz v11, :cond_c

    const-string v5, "http"

    invoke-virtual {v11, v5}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v5

    if-eqz v5, :cond_c

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/c/g;->a()Lcom/igexin/push/extension/distribution/basic/c/g;

    move-result-object v5

    invoke-virtual {v5, v11}, Lcom/igexin/push/extension/distribution/basic/c/g;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    const-string v6, ""

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_b

    const/4 v4, 0x1

    const/4 v5, 0x0

    invoke-virtual {v0, v5}, Lcom/igexin/push/extension/distribution/basic/b/m;->i(Z)V

    move v6, v4

    :goto_3
    if-nez v8, :cond_0

    if-nez v7, :cond_0

    if-nez v6, :cond_0

    if-eqz v9, :cond_d

    :cond_0
    if-eqz v8, :cond_1

    const/4 v5, 0x2

    move-object v0, p0

    move-object v4, p2

    invoke-virtual/range {v0 .. v5}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;I)V

    :cond_1
    if-eqz v7, :cond_2

    const/4 v5, 0x3

    move-object v0, p0

    move-object v1, v10

    move-object v4, p2

    invoke-virtual/range {v0 .. v5}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;I)V

    :cond_2
    if-eqz v6, :cond_3

    const/4 v5, 0x6

    move-object v0, p0

    move-object v1, v11

    move-object v4, p2

    invoke-virtual/range {v0 .. v5}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;I)V

    :cond_3
    if-eqz v9, :cond_4

    const/16 v5, 0x8

    move-object v0, p0

    move-object v1, v12

    move-object v4, p2

    invoke-virtual/range {v0 .. v5}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;I)V

    :cond_4
    sget-object v0, Lcom/igexin/push/core/b;->b:Lcom/igexin/push/core/b;

    :goto_4
    return-object v0

    :cond_5
    invoke-virtual {v0, v8}, Lcom/igexin/push/extension/distribution/basic/b/m;->c(Ljava/lang/String;)V

    :cond_6
    move v9, v7

    goto/16 :goto_0

    :cond_7
    invoke-virtual {v0, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->j(Ljava/lang/String;)V

    :cond_8
    move v8, v6

    goto :goto_1

    :cond_9
    invoke-virtual {v0, v6}, Lcom/igexin/push/extension/distribution/basic/b/m;->k(Ljava/lang/String;)V

    :cond_a
    move v7, v5

    goto :goto_2

    :cond_b
    invoke-virtual {v0, v5}, Lcom/igexin/push/extension/distribution/basic/b/m;->m(Ljava/lang/String;)V

    :cond_c
    move v6, v4

    goto :goto_3

    :cond_d
    sget-object v0, Lcom/igexin/push/core/b;->a:Lcom/igexin/push/core/b;

    goto :goto_4

    :cond_e
    sget-object v0, Lcom/igexin/push/core/b;->c:Lcom/igexin/push/core/b;

    goto :goto_4
.end method

.method public a(Lorg/json/JSONObject;)Lcom/igexin/push/core/bean/BaseAction;
    .locals 17

    :try_start_0
    sget-object v1, Lcom/igexin/push/extension/distribution/basic/c/j;->a:Landroid/content/Context;

    invoke-static {v1}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/k/l;

    move-result-object v4

    const-string v1, "getui_notification"

    const-string v2, "layout"

    invoke-virtual {v4, v1, v2}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v5

    const-string v1, "notification"

    const-string v2, "layout"

    invoke-virtual {v4, v1, v2}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v6

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/b/m;

    invoke-direct {v2}, Lcom/igexin/push/extension/distribution/basic/b/m;-><init>()V

    const-string v1, "notification"

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->setType(Ljava/lang/String;)V

    const-string v1, "actionid"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->setActionId(Ljava/lang/String;)V

    const-string v1, "do"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->setDoActionId(Ljava/lang/String;)V

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/c/c;->a:Lcom/igexin/push/extension/distribution/basic/c/c;

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(Lcom/igexin/push/extension/distribution/basic/c/c;)V

    const/4 v1, 0x1

    const-string v3, "notifyStyle"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_2

    move-result v3

    if-eqz v3, :cond_1

    :try_start_1
    const-string v1, "notifyStyle"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    move-result v1

    :goto_0
    const/4 v3, 0x6

    if-gt v1, v3, :cond_0

    if-gez v1, :cond_1

    :cond_0
    const/4 v1, 0x1

    :cond_1
    const/4 v3, 0x0

    :try_start_2
    const-string v7, "bigStyle"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_2

    move-result v7

    if-eqz v7, :cond_3

    :try_start_3
    const-string v3, "bigStyle"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_1

    move-result v3

    :goto_1
    const/4 v7, 0x3

    if-gt v3, v7, :cond_2

    const/4 v7, 0x1

    if-ge v3, v7, :cond_3

    :cond_2
    const/4 v3, 0x0

    :cond_3
    :try_start_4
    const-string v7, "getui_notification"

    const-string v8, "layout"

    invoke-virtual {v4, v7, v8}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v7

    const-string v8, "2.10.3.1"

    const-string v9, "2.6.0.0"

    invoke-static {v8, v9}, Lcom/igexin/push/extension/distribution/basic/util/g;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v8

    const/4 v9, -0x1

    if-eq v8, v9, :cond_4

    invoke-direct/range {p0 .. p0}, Lcom/igexin/push/extension/distribution/basic/a/o;->c()Z

    move-result v8

    if-eqz v8, :cond_4

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/c;->h()Z

    move-result v8

    if-nez v8, :cond_1b

    :cond_4
    const/4 v7, 0x6

    if-ne v1, v7, :cond_7

    const/4 v7, 0x1

    if-eq v3, v7, :cond_5

    const/4 v7, 0x2

    if-eq v3, v7, :cond_5

    if-nez v3, :cond_6

    :cond_5
    const/4 v1, 0x1

    :cond_6
    const/4 v7, 0x3

    if-ne v3, v7, :cond_7

    const/4 v1, 0x4

    :cond_7
    :goto_2
    invoke-virtual {v2, v3}, Lcom/igexin/push/extension/distribution/basic/b/m;->b(I)V

    if-eqz v5, :cond_8

    const-string v3, "getui_notification_style1"

    const-string v5, "id"

    invoke-virtual {v4, v3, v5}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    const-string v5, "getui_notification_style2"

    const-string v7, "id"

    invoke-virtual {v4, v5, v7}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v5

    const-string v7, "getui_notification_style3"

    const-string v8, "id"

    invoke-virtual {v4, v7, v8}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v7

    const-string v8, "getui_notification_icon"

    const-string v9, "id"

    invoke-virtual {v4, v8, v9}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v8

    const-string v9, "getui_notification_bg"

    const-string v10, "id"

    invoke-virtual {v4, v9, v10}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v9

    const-string v10, "getui_notification_date"

    const-string v11, "id"

    invoke-virtual {v4, v10, v11}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v10

    const-string v11, "getui_notification_icon2"

    const-string v12, "id"

    invoke-virtual {v4, v11, v12}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v11

    const-string v12, "getui_notification_style1_title"

    const-string v13, "id"

    invoke-virtual {v4, v12, v13}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v12

    const-string v13, "getui_notification_style1_content"

    const-string v14, "id"

    invoke-virtual {v4, v13, v14}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v13

    const-string v14, "getui_notification__style2_title"

    const-string v15, "id"

    invoke-virtual {v4, v14, v15}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v14

    const-string v15, "getui_notification_style3_content"

    const-string v16, "id"

    move-object/from16 v0, v16

    invoke-virtual {v4, v15, v0}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v15

    if-eqz v3, :cond_8

    if-eqz v5, :cond_8

    if-eqz v7, :cond_8

    if-eqz v8, :cond_8

    if-eqz v9, :cond_8

    if-eqz v10, :cond_8

    if-eqz v11, :cond_8

    if-eqz v12, :cond_8

    if-eqz v13, :cond_8

    if-eqz v14, :cond_8

    if-eqz v15, :cond_8

    sget-object v3, Lcom/igexin/push/extension/distribution/basic/c/c;->c:Lcom/igexin/push/extension/distribution/basic/c/c;

    invoke-virtual {v2, v3}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(Lcom/igexin/push/extension/distribution/basic/c/c;)V

    :cond_8
    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/b/m;->E()Lcom/igexin/push/extension/distribution/basic/c/c;

    move-result-object v3

    sget-object v5, Lcom/igexin/push/extension/distribution/basic/c/c;->a:Lcom/igexin/push/extension/distribution/basic/c/c;

    if-ne v3, v5, :cond_9

    if-eqz v6, :cond_9

    const-string v3, "notification_icon"

    const-string v5, "id"

    invoke-virtual {v4, v3, v5}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    const-string v5, "notification_background"

    const-string v6, "id"

    invoke-virtual {v4, v5, v6}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v5

    const-string v6, "notification_title"

    const-string v7, "id"

    invoke-virtual {v4, v6, v7}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v6

    const-string v7, "notification_name"

    const-string v8, "id"

    invoke-virtual {v4, v7, v8}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v4

    if-eqz v3, :cond_9

    if-eqz v5, :cond_9

    if-eqz v6, :cond_9

    if-nez v4, :cond_24

    :cond_9
    :goto_3
    const-string v3, "id"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_a

    const-string v3, "id"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(Ljava/lang/String;)V

    :cond_a
    const-string v3, "logo_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_b

    const-string v3, "logo_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    const-string v4, "http"

    invoke-virtual {v3, v4}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_b

    const-string v3, "logo_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igexin/push/extension/distribution/basic/b/m;->h(Ljava/lang/String;)V

    :cond_b
    const-string v3, "banner_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_c

    const-string v3, "banner_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    const-string v4, "http"

    invoke-virtual {v3, v4}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_c

    const-string v3, "banner_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igexin/push/extension/distribution/basic/b/m;->i(Ljava/lang/String;)V

    :cond_c
    const-string v3, "banner_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_d

    const-string v3, "banner_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    const-string v4, ""

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_d

    const/4 v3, 0x4

    if-ne v1, v3, :cond_d

    const/4 v3, 0x1

    invoke-virtual {v2, v3}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(Z)V

    :cond_d
    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->f(I)V

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/b/m;->E()Lcom/igexin/push/extension/distribution/basic/c/c;

    move-result-object v1

    sget-object v3, Lcom/igexin/push/extension/distribution/basic/c/c;->b:Lcom/igexin/push/extension/distribution/basic/c/c;

    if-ne v1, v3, :cond_e

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/b/m;->q()Ljava/lang/String;

    move-result-object v1

    if-nez v1, :cond_e

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/b/m;->r()Ljava/lang/String;

    move-result-object v1

    if-nez v1, :cond_e

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/c/c;->a:Lcom/igexin/push/extension/distribution/basic/c/c;

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(Lcom/igexin/push/extension/distribution/basic/c/c;)V

    :cond_e
    const-string v1, "title"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_f

    const-string v1, "title"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->e(Ljava/lang/String;)V

    :cond_f
    const-string v1, "text"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_10

    const-string v1, "text"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->f(Ljava/lang/String;)V

    :cond_10
    const-string v1, "logo"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_14

    const-string v1, ""

    const-string v3, "logo"

    move-object/from16 v0, p1

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_14

    const-string v1, "logo"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v3, ".png"

    invoke-virtual {v1, v3}, Ljava/lang/String;->lastIndexOf(Ljava/lang/String;)I

    move-result v3

    const/4 v4, -0x1

    if-ne v3, v4, :cond_11

    const-string v3, ".jpeg"

    invoke-virtual {v1, v3}, Ljava/lang/String;->lastIndexOf(Ljava/lang/String;)I

    move-result v3

    const/4 v4, -0x1

    if-eq v3, v4, :cond_25

    :cond_11
    const-string v3, ".png"

    invoke-virtual {v1, v3}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v3

    const/4 v4, -0x1

    if-ne v3, v4, :cond_12

    const-string v3, ".jpeg"

    invoke-virtual {v1, v3}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v3

    :cond_12
    const/4 v4, -0x1

    if-eq v3, v4, :cond_13

    const/4 v4, 0x0

    invoke-virtual {v1, v4, v3}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v1

    const-string v3, "^\\d+$"

    invoke-static {v3}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;)Ljava/util/regex/Pattern;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/util/regex/Pattern;->matcher(Ljava/lang/CharSequence;)Ljava/util/regex/Matcher;

    move-result-object v3

    invoke-virtual {v3}, Ljava/util/regex/Matcher;->matches()Z

    move-result v3

    if-eqz v3, :cond_13

    const-string v1, ""

    :cond_13
    :goto_4
    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->g(Ljava/lang/String;)V
    :try_end_4
    .catch Ljava/lang/Exception; {:try_start_4 .. :try_end_4} :catch_2

    :cond_14
    :try_start_5
    const-string v1, "timestamp"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_15

    const-string v1, "timestamp"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->j(Z)V
    :try_end_5
    .catch Ljava/lang/Exception; {:try_start_5 .. :try_end_5} :catch_4

    :cond_15
    :goto_5
    :try_start_6
    const-string v1, "second_icon_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_17

    const-string v1, "second_icon_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v3, "@url:http"

    invoke-virtual {v1, v3}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_16

    const-string v1, "second_icon_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v3, "@package:"

    invoke-virtual {v1, v3}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_17

    :cond_16
    const-string v1, "second_icon_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v3, "@url:http"

    invoke-virtual {v1, v3}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_26

    const/4 v3, 0x5

    invoke-virtual {v1, v3}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->l(Ljava/lang/String;)V

    :cond_17
    :goto_6
    const-string v1, "is_noclear"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_18

    const-string v1, "is_noclear"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->d(Z)V

    :cond_18
    const-string v1, "is_novibrate"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_19

    const-string v1, "is_novibrate"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->e(Z)V

    :cond_19
    const-string v1, "is_noring"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1a

    const-string v1, "is_noring"

    move-object/from16 v0, p1

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->f(Z)V
    :try_end_6
    .catch Ljava/lang/Exception; {:try_start_6 .. :try_end_6} :catch_2

    :cond_1a
    move-object v1, v2

    :goto_7
    return-object v1

    :catch_0
    move-exception v1

    const/4 v1, 0x1

    goto/16 :goto_0

    :catch_1
    move-exception v3

    const/4 v3, 0x0

    goto/16 :goto_1

    :cond_1b
    if-eqz v7, :cond_23

    :try_start_7
    const-string v7, "priority"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_1c

    const-string v7, "priority"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v7

    const/4 v8, -0x3

    if-le v7, v8, :cond_1e

    const/4 v8, 0x3

    if-ge v7, v8, :cond_1e

    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(I)V
    :try_end_7
    .catch Ljava/lang/Exception; {:try_start_7 .. :try_end_7} :catch_3

    :cond_1c
    :goto_8
    const/4 v7, 0x6

    if-ne v1, v7, :cond_22

    if-eqz v3, :cond_22

    const/4 v7, 0x1

    if-ne v3, v7, :cond_1f

    :try_start_8
    const-string v7, "big_image_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_1f

    const-string v7, "big_image_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    const-string v8, "http"

    invoke-virtual {v7, v8}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_1f

    const-string v7, "big_image_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->d(Ljava/lang/String;)V

    :cond_1d
    :goto_9
    const-string v7, "isFloat"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_7

    sget v7, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v8, 0xb

    if-lt v7, v8, :cond_7

    const-string v7, "isFloat"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v7

    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->b(Z)V
    :try_end_8
    .catch Ljava/lang/Exception; {:try_start_8 .. :try_end_8} :catch_2

    goto/16 :goto_2

    :catch_2
    move-exception v1

    const/4 v1, 0x0

    goto :goto_7

    :cond_1e
    const/4 v7, 0x0

    :try_start_9
    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(I)V
    :try_end_9
    .catch Ljava/lang/Exception; {:try_start_9 .. :try_end_9} :catch_3

    goto :goto_8

    :catch_3
    move-exception v7

    const/4 v7, 0x0

    :try_start_a
    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(I)V

    goto :goto_8

    :cond_1f
    const/4 v7, 0x2

    if-ne v3, v7, :cond_20

    const-string v7, "big_text"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_20

    const-string v7, "big_text"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    const-string v8, ""

    invoke-virtual {v7, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_20

    const-string v7, "big_text"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->b(Ljava/lang/String;)V

    goto :goto_9

    :cond_20
    const/4 v7, 0x3

    if-ne v3, v7, :cond_21

    const-string v7, "big_image_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_21

    const-string v7, "big_image_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    const-string v8, "http"

    invoke-virtual {v7, v8}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_21

    const-string v7, "banner_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_21

    const-string v7, "banner_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    const-string v8, "http"

    invoke-virtual {v7, v8}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_21

    const-string v7, "big_image_url"

    move-object/from16 v0, p1

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->d(Ljava/lang/String;)V

    goto/16 :goto_9

    :cond_21
    const/4 v7, 0x1

    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(Z)V

    goto/16 :goto_9

    :cond_22
    const/4 v7, 0x6

    if-ne v1, v7, :cond_1d

    if-nez v3, :cond_1d

    const/4 v7, 0x1

    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(Z)V

    goto/16 :goto_9

    :cond_23
    const/4 v7, 0x1

    invoke-virtual {v2, v7}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(Z)V

    goto/16 :goto_2

    :cond_24
    sget-object v3, Lcom/igexin/push/extension/distribution/basic/c/c;->b:Lcom/igexin/push/extension/distribution/basic/c/c;

    invoke-virtual {v2, v3}, Lcom/igexin/push/extension/distribution/basic/b/m;->a(Lcom/igexin/push/extension/distribution/basic/c/c;)V

    goto/16 :goto_3

    :cond_25
    const-string v1, ""

    goto/16 :goto_4

    :cond_26
    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->l(Ljava/lang/String;)V
    :try_end_a
    .catch Ljava/lang/Exception; {:try_start_a .. :try_end_a} :catch_2

    goto/16 :goto_6

    :catch_4
    move-exception v1

    goto/16 :goto_5
.end method

.method public a(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/b/m;I)V
    .locals 18

    sget-object v2, Lcom/igexin/push/core/g;->ai:Ljava/util/Map;

    invoke-static/range {p4 .. p4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    move-object/from16 v0, p1

    invoke-interface {v2, v0, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const/4 v7, 0x0

    move-object/from16 v2, p0

    move-object/from16 v3, p1

    move-object/from16 v4, p2

    move/from16 v5, p4

    move-object/from16 v6, p3

    invoke-direct/range {v2 .. v7}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Ljava/lang/String;Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/b/m;Z)Landroid/app/PendingIntent;

    move-result-object v6

    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    const-string v3, "notification"

    invoke-virtual {v2, v3}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/app/NotificationManager;

    new-instance v3, Landroid/app/Notification;

    invoke-direct {v3}, Landroid/app/Notification;-><init>()V

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->l()Ljava/lang/String;

    move-result-object v4

    iput-object v4, v3, Landroid/app/Notification;->tickerText:Ljava/lang/CharSequence;

    move-object/from16 v0, p0

    move-object/from16 v1, p3

    invoke-direct {v0, v3, v1}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Landroid/app/Notification;Lcom/igexin/push/extension/distribution/basic/b/m;)Landroid/app/Notification;

    move-result-object v4

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->s()Ljava/lang/String;

    move-result-object v5

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->t()Ljava/lang/String;

    move-result-object v7

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->k()Ljava/lang/String;

    move-result-object v8

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->l()Ljava/lang/String;

    move-result-object v9

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->E()Lcom/igexin/push/extension/distribution/basic/c/c;

    move-result-object v3

    sget-object v10, Lcom/igexin/push/extension/distribution/basic/c/c;->a:Lcom/igexin/push/extension/distribution/basic/c/c;

    if-eq v3, v10, :cond_1

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->E()Lcom/igexin/push/extension/distribution/basic/c/c;

    move-result-object v3

    sget-object v10, Lcom/igexin/push/extension/distribution/basic/c/c;->c:Lcom/igexin/push/extension/distribution/basic/c/c;

    if-ne v3, v10, :cond_0

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v3

    if-eqz v3, :cond_1

    :cond_0
    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/c;->e()Z

    move-result v3

    if-eqz v3, :cond_a

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v3

    const/4 v10, 0x1

    if-ne v3, v10, :cond_a

    :cond_1
    const/4 v3, 0x0

    if-eqz v5, :cond_2

    const-string v7, ""

    invoke-virtual {v7, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_2

    invoke-static {v5}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v5

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v7, Lcom/igexin/push/extension/distribution/basic/a/o;->a:Ljava/lang/String;

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v7, "|use net logo bitmap is null = "

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    if-nez v5, :cond_6

    const/4 v3, 0x1

    :goto_0
    invoke-virtual {v7, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    move-object v3, v5

    :cond_2
    if-nez v3, :cond_3

    const/4 v3, 0x0

    move-object/from16 v0, p0

    move-object/from16 v1, p3

    invoke-direct {v0, v1, v3}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Lcom/igexin/push/extension/distribution/basic/b/m;Z)I

    move-result v3

    sget-object v5, Lcom/igexin/push/extension/distribution/basic/c/j;->a:Landroid/content/Context;

    invoke-virtual {v5}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v5

    invoke-static {v5, v3}, Landroid/graphics/BitmapFactory;->decodeResource(Landroid/content/res/Resources;I)Landroid/graphics/Bitmap;

    move-result-object v3

    :cond_3
    sget v5, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v7, 0xb

    if-lt v5, v7, :cond_7

    new-instance v5, Landroid/app/Notification$Builder;

    sget-object v7, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-direct {v5, v7}, Landroid/app/Notification$Builder;-><init>(Landroid/content/Context;)V

    iget v7, v4, Landroid/app/Notification;->icon:I

    invoke-virtual {v5, v7}, Landroid/app/Notification$Builder;->setSmallIcon(I)Landroid/app/Notification$Builder;

    move-result-object v5

    iget-object v4, v4, Landroid/app/Notification;->tickerText:Ljava/lang/CharSequence;

    invoke-virtual {v5, v4}, Landroid/app/Notification$Builder;->setTicker(Ljava/lang/CharSequence;)Landroid/app/Notification$Builder;

    move-result-object v4

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v10

    invoke-virtual {v4, v10, v11}, Landroid/app/Notification$Builder;->setWhen(J)Landroid/app/Notification$Builder;

    move-result-object v4

    invoke-virtual {v4, v8}, Landroid/app/Notification$Builder;->setContentTitle(Ljava/lang/CharSequence;)Landroid/app/Notification$Builder;

    move-result-object v4

    invoke-virtual {v4, v3}, Landroid/app/Notification$Builder;->setLargeIcon(Landroid/graphics/Bitmap;)Landroid/app/Notification$Builder;

    move-result-object v3

    invoke-virtual {v3, v6}, Landroid/app/Notification$Builder;->setContentIntent(Landroid/app/PendingIntent;)Landroid/app/Notification$Builder;

    move-result-object v3

    invoke-virtual {v3, v9}, Landroid/app/Notification$Builder;->setContentText(Ljava/lang/CharSequence;)Landroid/app/Notification$Builder;

    move-result-object v3

    invoke-virtual {v3}, Landroid/app/Notification$Builder;->getNotification()Landroid/app/Notification;

    move-result-object v3

    move-object/from16 v0, p0

    move-object/from16 v1, p3

    invoke-direct {v0, v3, v1}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Landroid/app/Notification;Lcom/igexin/push/extension/distribution/basic/b/m;)Landroid/app/Notification;

    move-result-object v3

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/c;->e()Z

    move-result v4

    if-nez v4, :cond_4

    sget v4, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v5, 0x15

    if-lt v4, v5, :cond_4

    sget v4, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v5, 0x18

    if-ge v4, v5, :cond_4

    :try_start_0
    const-string v4, "com.android.internal.R$id"

    invoke-static {v4}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v4

    const-string v5, "right_icon"

    invoke-virtual {v4, v5}, Ljava/lang/Class;->getField(Ljava/lang/String;)Ljava/lang/reflect/Field;

    move-result-object v4

    const/4 v5, 0x1

    invoke-virtual {v4, v5}, Ljava/lang/reflect/Field;->setAccessible(Z)V

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Ljava/lang/reflect/Field;->getInt(Ljava/lang/Object;)I

    move-result v4

    iget-object v5, v3, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    if-eqz v5, :cond_4

    iget-object v5, v3, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/16 v6, 0x8

    invoke-virtual {v5, v4, v6}, Landroid/widget/RemoteViews;->setViewVisibility(II)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1

    :cond_4
    :goto_1
    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/c;->g()Z

    move-result v4

    if-nez v4, :cond_9

    move/from16 v0, p4

    invoke-virtual {v2, v0, v3}, Landroid/app/NotificationManager;->notify(ILandroid/app/Notification;)V

    :cond_5
    :goto_2
    return-void

    :cond_6
    const/4 v3, 0x0

    goto/16 :goto_0

    :cond_7
    :try_start_1
    iget-object v5, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    if-eqz v5, :cond_8

    if-eqz v3, :cond_8

    invoke-direct/range {p0 .. p0}, Lcom/igexin/push/extension/distribution/basic/a/o;->a()I

    move-result v5

    if-lez v5, :cond_8

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v7, v5, v3}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    :cond_8
    const-string v3, "android.app.Notification"

    invoke-static {v3}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v3

    const-string v5, "setLatestEventInfo"

    const/4 v7, 0x4

    new-array v7, v7, [Ljava/lang/Class;

    const/4 v10, 0x0

    const-class v11, Landroid/content/Context;

    aput-object v11, v7, v10

    const/4 v10, 0x1

    const-class v11, Ljava/lang/CharSequence;

    aput-object v11, v7, v10

    const/4 v10, 0x2

    const-class v11, Ljava/lang/CharSequence;

    aput-object v11, v7, v10

    const/4 v10, 0x3

    const-class v11, Landroid/app/PendingIntent;

    aput-object v11, v7, v10

    invoke-virtual {v3, v5, v7}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v3

    const/4 v5, 0x1

    invoke-virtual {v3, v5}, Ljava/lang/reflect/Method;->setAccessible(Z)V

    const/4 v5, 0x4

    new-array v5, v5, [Ljava/lang/Object;

    const/4 v7, 0x0

    sget-object v10, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    aput-object v10, v5, v7

    const/4 v7, 0x1

    aput-object v8, v5, v7

    const/4 v7, 0x2

    aput-object v9, v5, v7

    const/4 v7, 0x3

    aput-object v6, v5, v7

    invoke-virtual {v3, v4, v5}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    move-object v3, v4

    goto :goto_1

    :catch_0
    move-exception v2

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v3, Lcom/igexin/push/extension/distribution/basic/a/o;->a:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "reflect invoke setLatestEventInfo failed!"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    goto :goto_2

    :cond_9
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v4

    const/4 v5, 0x4

    if-eq v4, v5, :cond_5

    move-object v4, v3

    :goto_3
    move/from16 v0, p4

    invoke-static {v2, v0, v4}, Lcom/igexin/push/extension/distribution/basic/util/p;->a(Landroid/app/NotificationManager;ILandroid/app/Notification;)V

    goto :goto_2

    :cond_a
    sget-object v3, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/k/l;

    move-result-object v10

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->E()Lcom/igexin/push/extension/distribution/basic/c/c;

    move-result-object v3

    sget-object v11, Lcom/igexin/push/extension/distribution/basic/c/c;->b:Lcom/igexin/push/extension/distribution/basic/c/c;

    if-ne v3, v11, :cond_11

    const-string v3, "notification"

    const-string v11, "layout"

    invoke-virtual {v10, v3, v11}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    new-instance v11, Landroid/widget/RemoteViews;

    sget-object v12, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    invoke-direct {v11, v12, v3}, Landroid/widget/RemoteViews;-><init>(Ljava/lang/String;I)V

    iput-object v11, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const-string v3, "notification_icon"

    const-string v11, "id"

    invoke-virtual {v10, v3, v11}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v11

    const-string v3, "notification_background"

    const-string v12, "id"

    invoke-virtual {v10, v3, v12}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v12

    const-string v3, "update_notification_progressblock"

    const-string v13, "id"

    invoke-virtual {v10, v3, v13}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v13

    const-string v3, "notification_title"

    const-string v14, "id"

    invoke-virtual {v10, v3, v14}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v14

    const-string v3, "notification_name"

    const-string v15, "id"

    invoke-virtual {v10, v3, v15}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v15

    const/4 v3, 0x0

    if-eqz v5, :cond_b

    invoke-static {v5}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v5

    if-eqz v5, :cond_b

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v11, v5}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    const/4 v3, 0x1

    :cond_b
    if-nez v3, :cond_c

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/4 v5, 0x0

    move-object/from16 v0, p0

    move-object/from16 v1, p3

    invoke-direct {v0, v1, v5}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Lcom/igexin/push/extension/distribution/basic/b/m;Z)I

    move-result v5

    invoke-virtual {v3, v11, v5}, Landroid/widget/RemoteViews;->setImageViewResource(II)V

    :cond_c
    if-eqz v7, :cond_d

    invoke-static {v7}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v3

    if-eqz v3, :cond_d

    iget-object v5, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v5, v12, v3}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    :cond_d
    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->a()Z

    move-result v3

    if-eqz v3, :cond_e

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->b()Z

    move-result v3

    if-eqz v3, :cond_e

    const/16 v3, 0x20

    const/16 v5, 0x20

    const/16 v7, 0x20

    invoke-static {v3, v5, v7}, Landroid/graphics/Color;->rgb(III)I

    move-result v3

    iget-object v5, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v5, v14, v3}, Landroid/widget/RemoteViews;->setTextColor(II)V

    :cond_e
    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v14, v8}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v15, v9}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    if-eqz v13, :cond_f

    const-string v3, "app_download_notification"

    const-string v5, "layout"

    invoke-virtual {v10, v3, v5}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    if-nez v3, :cond_10

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/16 v5, 0x8

    invoke-virtual {v3, v13, v5}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    :cond_f
    :goto_4
    iput-object v6, v4, Landroid/app/Notification;->contentIntent:Landroid/app/PendingIntent;

    goto/16 :goto_3

    :cond_10
    const-string v3, "2.10.3.1"

    const-string v5, "2.3.0.0"

    invoke-static {v3, v5}, Lcom/igexin/push/extension/distribution/basic/util/g;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    const/4 v5, -0x1

    if-eq v3, v5, :cond_f

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/16 v5, 0x8

    invoke-virtual {v3, v13, v5}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    goto :goto_4

    :cond_11
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->E()Lcom/igexin/push/extension/distribution/basic/c/c;

    move-result-object v3

    sget-object v11, Lcom/igexin/push/extension/distribution/basic/c/c;->c:Lcom/igexin/push/extension/distribution/basic/c/c;

    if-ne v3, v11, :cond_5

    const-string v3, "getui_notification"

    const-string v11, "layout"

    invoke-virtual {v10, v3, v11}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    const-string v11, "getui_notification_icon"

    const-string v12, "id"

    invoke-virtual {v10, v11, v12}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v11

    const-string v12, "getui_notification_bg"

    const-string v13, "id"

    invoke-virtual {v10, v12, v13}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v12

    const-string v13, "getui_notification_date"

    const-string v14, "id"

    invoke-virtual {v10, v13, v14}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v13

    const-string v14, "getui_notification_icon2"

    const-string v15, "id"

    invoke-virtual {v10, v14, v15}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v14

    new-instance v15, Landroid/widget/RemoteViews;

    sget-object v16, Lcom/igexin/push/core/g;->e:Ljava/lang/String;

    move-object/from16 v0, v16

    invoke-direct {v15, v0, v3}, Landroid/widget/RemoteViews;-><init>(Ljava/lang/String;I)V

    iput-object v15, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/util/c;->a(I)Z

    move-result v15

    if-eqz v15, :cond_12

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    sget-object v16, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static/range {v16 .. v16}, Lcom/igexin/push/extension/distribution/basic/util/o;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/util/o;

    move-result-object v16

    invoke-virtual/range {v16 .. v16}, Lcom/igexin/push/extension/distribution/basic/util/o;->c()I

    move-result v16

    move/from16 v0, v16

    invoke-virtual {v3, v13, v0}, Landroid/widget/RemoteViews;->setTextColor(II)V

    sget v3, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v16, 0x10

    move/from16 v0, v16

    if-lt v3, v0, :cond_12

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/16 v16, 0x0

    sget-object v17, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static/range {v17 .. v17}, Lcom/igexin/push/extension/distribution/basic/util/o;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/util/o;

    move-result-object v17

    invoke-virtual/range {v17 .. v17}, Lcom/igexin/push/extension/distribution/basic/util/o;->f()F

    move-result v17

    move/from16 v0, v16

    move/from16 v1, v17

    invoke-virtual {v3, v13, v0, v1}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    :cond_12
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v16

    const/4 v3, 0x4

    move/from16 v0, v16

    if-eq v0, v3, :cond_16

    const/4 v3, 0x0

    if-eqz v5, :cond_13

    invoke-static {v5}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v5

    if-eqz v5, :cond_13

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v11, v5}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    const/4 v3, 0x1

    :cond_13
    if-nez v3, :cond_14

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/4 v5, 0x0

    move-object/from16 v0, p0

    move-object/from16 v1, p3

    invoke-direct {v0, v1, v5}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Lcom/igexin/push/extension/distribution/basic/b/m;Z)I

    move-result v5

    invoke-virtual {v3, v11, v5}, Landroid/widget/RemoteViews;->setImageViewResource(II)V

    :cond_14
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->C()Z

    move-result v3

    if-eqz v3, :cond_15

    new-instance v3, Ljava/text/SimpleDateFormat;

    const-string v5, "HH:mm"

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v11

    invoke-direct {v3, v5, v11}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    new-instance v5, Ljava/util/Date;

    invoke-direct {v5}, Ljava/util/Date;-><init>()V

    invoke-virtual {v3, v5}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v3

    iget-object v5, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v5, v13, v3}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    :cond_15
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->D()Ljava/lang/String;

    move-result-object v3

    if-eqz v3, :cond_18

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v3

    if-eqz v3, :cond_16

    iget-object v5, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v5, v14, v3}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    :cond_16
    :goto_5
    if-eqz v7, :cond_1a

    invoke-static {v7}, Lcom/igexin/push/extension/distribution/basic/util/m;->b(Ljava/lang/String;)Landroid/graphics/Bitmap;

    move-result-object v3

    if-eqz v3, :cond_19

    iget-object v5, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v5, v12, v3}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    :cond_17
    const/4 v3, 0x1

    move/from16 v0, v16

    if-ne v0, v3, :cond_1d

    const-string v3, "getui_notification_style1"

    const-string v5, "id"

    invoke-virtual {v10, v3, v5}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    const-string v5, "getui_notification_style1_title"

    const-string v7, "id"

    invoke-virtual {v10, v5, v7}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v5

    const-string v7, "getui_notification_style1_content"

    const-string v11, "id"

    invoke-virtual {v10, v7, v11}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v7

    iget-object v10, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/4 v11, 0x0

    invoke-virtual {v10, v3, v11}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v5, v8}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v7, v9}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    if-eqz v15, :cond_1c

    sget-object v3, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/util/o;

    move-result-object v3

    iget-object v10, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->a()I

    move-result v11

    invoke-virtual {v10, v5, v11}, Landroid/widget/RemoteViews;->setTextColor(II)V

    iget-object v10, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->b()I

    move-result v11

    invoke-virtual {v10, v7, v11}, Landroid/widget/RemoteViews;->setTextColor(II)V

    sget v10, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v11, 0x10

    if-lt v10, v11, :cond_1b

    iget-object v8, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/4 v9, 0x0

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->d()F

    move-result v10

    invoke-virtual {v8, v5, v9, v10}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    iget-object v5, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/4 v8, 0x0

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->e()F

    move-result v3

    invoke-virtual {v5, v7, v8, v3}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    goto/16 :goto_4

    :cond_18
    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->z()Ljava/lang/String;

    move-result-object v3

    if-eqz v3, :cond_16

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->z()Ljava/lang/String;

    move-result-object v3

    const-string v5, "@package:"

    invoke-virtual {v3, v5}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_16

    invoke-virtual/range {p3 .. p3}, Lcom/igexin/push/extension/distribution/basic/b/m;->z()Ljava/lang/String;

    move-result-object v3

    const/16 v5, 0x9

    invoke-virtual {v3, v5}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/util/m;->a(Ljava/lang/String;)Landroid/graphics/drawable/Drawable;

    move-result-object v3

    if-eqz v3, :cond_16

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/util/m;->a(Landroid/graphics/drawable/Drawable;)Landroid/graphics/Bitmap;

    move-result-object v3

    if-eqz v3, :cond_16

    iget-object v5, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v5, v14, v3}, Landroid/widget/RemoteViews;->setImageViewBitmap(ILandroid/graphics/Bitmap;)V

    goto/16 :goto_5

    :cond_19
    const/4 v3, 0x4

    move/from16 v0, v16

    if-ne v0, v3, :cond_17

    goto/16 :goto_2

    :cond_1a
    const/4 v3, 0x4

    move/from16 v0, v16

    if-ne v0, v3, :cond_17

    goto/16 :goto_2

    :cond_1b
    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "<font> <h4>"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v10, "</h4></font>"

    invoke-virtual {v8, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-static {v8}, Landroid/text/Html;->fromHtml(Ljava/lang/String;)Landroid/text/Spanned;

    move-result-object v8

    invoke-virtual {v3, v5, v8}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v7, v9}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    goto/16 :goto_4

    :cond_1c
    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->a()Z

    move-result v3

    if-eqz v3, :cond_f

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->b()Z

    move-result v3

    if-eqz v3, :cond_f

    const/16 v3, 0x20

    const/16 v7, 0x20

    const/16 v8, 0x20

    invoke-static {v3, v7, v8}, Landroid/graphics/Color;->rgb(III)I

    move-result v3

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v7, v5, v3}, Landroid/widget/RemoteViews;->setTextColor(II)V

    goto/16 :goto_4

    :cond_1d
    const/4 v3, 0x2

    move/from16 v0, v16

    if-ne v0, v3, :cond_20

    const-string v3, "getui_notification_style2"

    const-string v5, "id"

    invoke-virtual {v10, v3, v5}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    const-string v5, "getui_notification__style2_title"

    const-string v7, "id"

    invoke-virtual {v10, v5, v7}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v5

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/4 v9, 0x0

    invoke-virtual {v7, v3, v9}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v5, v8}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    if-eqz v15, :cond_1f

    sget-object v3, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/util/o;

    move-result-object v3

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->a()I

    move-result v9

    invoke-virtual {v7, v5, v9}, Landroid/widget/RemoteViews;->setTextColor(II)V

    sget v7, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v9, 0x10

    if-lt v7, v9, :cond_1e

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/4 v8, 0x0

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->d()F

    move-result v3

    invoke-virtual {v7, v5, v8, v3}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    goto/16 :goto_4

    :cond_1e
    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "<font> <h4>"

    invoke-virtual {v7, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    const-string v8, "</h4></font>"

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v7}, Landroid/text/Html;->fromHtml(Ljava/lang/String;)Landroid/text/Spanned;

    move-result-object v7

    invoke-virtual {v3, v5, v7}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    goto/16 :goto_4

    :cond_1f
    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->a()Z

    move-result v3

    if-eqz v3, :cond_f

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->b()Z

    move-result v3

    if-eqz v3, :cond_f

    const/16 v3, 0x20

    const/16 v7, 0x20

    const/16 v8, 0x20

    invoke-static {v3, v7, v8}, Landroid/graphics/Color;->rgb(III)I

    move-result v3

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v7, v5, v3}, Landroid/widget/RemoteViews;->setTextColor(II)V

    goto/16 :goto_4

    :cond_20
    const/4 v3, 0x3

    move/from16 v0, v16

    if-ne v0, v3, :cond_f

    const-string v3, "getui_notification_style3"

    const-string v5, "id"

    invoke-virtual {v10, v3, v5}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v3

    const-string v5, "getui_notification_style3_content"

    const-string v7, "id"

    invoke-virtual {v10, v5, v7}, Lcom/igexin/push/extension/distribution/basic/k/l;->a(Ljava/lang/String;Ljava/lang/String;)I

    move-result v5

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/4 v8, 0x0

    invoke-virtual {v7, v3, v8}, Landroid/widget/RemoteViews;->setViewVisibility(II)V

    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v5, v9}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    if-eqz v15, :cond_22

    sget-object v3, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->a(Landroid/content/Context;)Lcom/igexin/push/extension/distribution/basic/util/o;

    move-result-object v3

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->b()I

    move-result v8

    invoke-virtual {v7, v5, v8}, Landroid/widget/RemoteViews;->setTextColor(II)V

    sget v7, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v8, 0x10

    if-lt v7, v8, :cond_21

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    const/4 v8, 0x0

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/util/o;->e()F

    move-result v3

    invoke-virtual {v7, v5, v8, v3}, Landroid/widget/RemoteViews;->setTextViewTextSize(IIF)V

    goto/16 :goto_4

    :cond_21
    iget-object v3, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v3, v5, v9}, Landroid/widget/RemoteViews;->setTextViewText(ILjava/lang/CharSequence;)V

    goto/16 :goto_4

    :cond_22
    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->a()Z

    move-result v3

    if-eqz v3, :cond_f

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/e;->b()Z

    move-result v3

    if-eqz v3, :cond_f

    const/16 v3, 0x99

    const/16 v7, 0x99

    const/16 v8, 0x99

    invoke-static {v3, v7, v8}, Landroid/graphics/Color;->rgb(III)I

    move-result v3

    iget-object v7, v4, Landroid/app/Notification;->contentView:Landroid/widget/RemoteViews;

    invoke-virtual {v7, v5, v3}, Landroid/widget/RemoteViews;->setTextColor(II)V

    goto/16 :goto_4

    :catch_1
    move-exception v4

    goto/16 :goto_1
.end method

.method public a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;I)V
    .locals 9

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "width="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget v1, Lcom/igexin/push/extension/distribution/basic/c/j;->c:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "&height="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget v1, Lcom/igexin/push/extension/distribution/basic/c/j;->b:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p1, v0}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_5

    const-string v1, "?"

    invoke-virtual {p1, v1}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v1

    if-lez v1, :cond_1

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    move-object v7, v0

    :goto_0
    new-instance v8, Lcom/igexin/push/extension/distribution/basic/h/d;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/a/p;

    move-object v1, p0

    move-object v2, p4

    move-object v3, p2

    move-object v4, p3

    move-object v5, p1

    move v6, p5

    invoke-direct/range {v0 .. v6}, Lcom/igexin/push/extension/distribution/basic/a/p;-><init>(Lcom/igexin/push/extension/distribution/basic/a/o;Lcom/igexin/push/core/bean/BaseAction;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V

    move-object v1, v8

    move-object v2, v7

    move-object v3, p1

    move-object v4, p2

    move-object v5, p4

    move v6, p5

    move-object v7, v0

    invoke-direct/range {v1 .. v7}, Lcom/igexin/push/extension/distribution/basic/h/d;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;ILcom/igexin/push/extension/distribution/basic/h/g;)V

    const/4 v0, 0x2

    if-ne p5, v0, :cond_2

    move-object v0, p4

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/m;

    check-cast p4, Lcom/igexin/push/extension/distribution/basic/b/m;

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->w()I

    move-result v1

    add-int/lit8 v1, v1, 0x1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->d(I)V

    :cond_0
    :goto_1
    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/h/a;

    invoke-direct {v1, v8}, Lcom/igexin/push/extension/distribution/basic/h/a;-><init>(Lcom/igexin/push/extension/distribution/basic/h/f;)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    return-void

    :cond_1
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "?"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    move-object v7, v0

    goto :goto_0

    :cond_2
    const/4 v0, 0x3

    if-ne p5, v0, :cond_3

    move-object v0, p4

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/m;

    check-cast p4, Lcom/igexin/push/extension/distribution/basic/b/m;

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->x()I

    move-result v1

    add-int/lit8 v1, v1, 0x1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->e(I)V

    goto :goto_1

    :cond_3
    const/4 v0, 0x6

    if-ne p5, v0, :cond_4

    move-object v0, p4

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/m;

    check-cast p4, Lcom/igexin/push/extension/distribution/basic/b/m;

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->B()I

    move-result v1

    add-int/lit8 v1, v1, 0x1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->g(I)V

    goto :goto_1

    :cond_4
    const/16 v0, 0x8

    if-ne p5, v0, :cond_0

    move-object v0, p4

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/m;

    check-cast p4, Lcom/igexin/push/extension/distribution/basic/b/m;

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/m;->i()I

    move-result v1

    add-int/lit8 v1, v1, 0x1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/b/m;->c(I)V

    goto :goto_1

    :cond_5
    move-object v7, p1

    goto/16 :goto_0
.end method

.method public b(Lcom/igexin/push/core/bean/PushTaskBean;Lcom/igexin/push/core/bean/BaseAction;)Z
    .locals 6

    if-eqz p1, :cond_2

    if-eqz p2, :cond_2

    instance-of v0, p2, Lcom/igexin/push/extension/distribution/basic/b/m;

    if-eqz v0, :cond_2

    check-cast p2, Lcom/igexin/push/extension/distribution/basic/b/m;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    long-to-int v1, v0

    const/4 v0, 0x0

    :try_start_0
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->getActionId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->getActionId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v3

    add-int/lit8 v3, v3, -0x1

    invoke-virtual {v2, v3}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1

    move-result v0

    add-int/lit16 v0, v0, 0x7530

    :goto_0
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->d()Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/a/o;->b()Z

    move-result v2

    if-eqz v2, :cond_0

    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v3, 0xb

    if-lt v2, v3, :cond_0

    :try_start_1
    invoke-virtual {p1}, Lcom/igexin/push/core/bean/PushTaskBean;->getTaskId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p1}, Lcom/igexin/push/core/bean/PushTaskBean;->getMessageId()Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v2, v3, p2, v1}, Lcom/igexin/push/extension/distribution/basic/a/o;->b(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/b/m;I)V

    if-eqz v0, :cond_0

    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v2

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ""

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "notifyFloat:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->f()I

    move-result v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, p1, v3, v4}, Lcom/igexin/push/core/a/e;->a(Lcom/igexin/push/core/bean/PushTaskBean;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0

    :cond_0
    :goto_1
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v2

    const/4 v3, 0x6

    if-ne v2, v3, :cond_3

    invoke-virtual {p1}, Lcom/igexin/push/core/bean/PushTaskBean;->getTaskId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p1}, Lcom/igexin/push/core/bean/PushTaskBean;->getMessageId()Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v2, v3, p2, v1}, Lcom/igexin/push/extension/distribution/basic/a/o;->c(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/b/m;I)V

    if-eqz v0, :cond_1

    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, ""

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "notifyStyle:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, p1, v0, v2}, Lcom/igexin/push/core/a/e;->a(Lcom/igexin/push/core/bean/PushTaskBean;Ljava/lang/String;Ljava/lang/String;)V

    :cond_1
    :goto_2
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->getActionId()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v0

    invoke-virtual {p1, v0}, Lcom/igexin/push/core/bean/PushTaskBean;->setPerActionid(I)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->getDoActionId()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v0

    invoke-virtual {p1, v0}, Lcom/igexin/push/core/bean/PushTaskBean;->setCurrentActionid(I)V

    :cond_2
    const/4 v0, 0x1

    return v0

    :cond_3
    invoke-virtual {p1}, Lcom/igexin/push/core/bean/PushTaskBean;->getTaskId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p1}, Lcom/igexin/push/core/bean/PushTaskBean;->getMessageId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {p0, v2, v3, p2, v1}, Lcom/igexin/push/extension/distribution/basic/a/o;->a(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/b/m;I)V

    if-eqz v0, :cond_1

    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, ""

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "notifyStyle:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/b/m;->y()I

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, p1, v0, v2}, Lcom/igexin/push/core/a/e;->a(Lcom/igexin/push/core/bean/PushTaskBean;Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_2

    :catch_0
    move-exception v2

    goto/16 :goto_1

    :catch_1
    move-exception v2

    goto/16 :goto_0
.end method
