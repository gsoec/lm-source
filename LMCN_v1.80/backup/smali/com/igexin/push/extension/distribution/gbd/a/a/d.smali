.class public Lcom/igexin/push/extension/distribution/gbd/a/a/d;
.super Ljava/lang/Object;


# static fields
.field private static a:Lcom/igexin/push/extension/distribution/gbd/a/a/d;


# instance fields
.field private b:Landroid/content/pm/PackageManager;


# direct methods
.method private constructor <init>()V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->a:Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/a/a/d;->b:Landroid/content/pm/PackageManager;

    return-void
.end method

.method public static a()Lcom/igexin/push/extension/distribution/gbd/a/a/d;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/a/a/d;->a:Lcom/igexin/push/extension/distribution/gbd/a/a/d;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/gbd/a/a/d;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/gbd/a/a/d;-><init>()V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/a/a/d;->a:Lcom/igexin/push/extension/distribution/gbd/a/a/d;

    :cond_0
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/a/a/d;->a:Lcom/igexin/push/extension/distribution/gbd/a/a/d;

    return-object v0
.end method


# virtual methods
.method public a(Landroid/content/Intent;)V
    .locals 9

    :try_start_0
    new-instance v0, Ljava/lang/Thread;

    new-instance v1, Lcom/igexin/push/extension/distribution/gbd/a/a/e;

    invoke-direct {v1, p0}, Lcom/igexin/push/extension/distribution/gbd/a/a/e;-><init>(Lcom/igexin/push/extension/distribution/gbd/a/a/d;)V

    invoke-direct {v0, v1}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    invoke-virtual {v0}, Ljava/lang/Thread;->start()V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    :try_start_1
    invoke-virtual {p1}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object v0

    const-string v1, "android.intent.action.PACKAGE_ADDED"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_0

    const-string v1, "android.intent.action.PACKAGE_REMOVED"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    :cond_0
    invoke-virtual {p1}, Landroid/content/Intent;->getDataString()Ljava/lang/String;

    move-result-object v1

    const-string v2, "GBD_RPRA"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "doSample pkgName = "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V

    const-string v2, ":"

    invoke-virtual {v1, v2}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v2

    const/4 v3, -0x1

    if-eq v2, v3, :cond_1

    add-int/lit8 v2, v2, 0x1

    invoke-virtual {v1, v2}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v2

    const-string v3, ""

    const-string v1, "none"

    const-string v1, "none"

    const-string v1, "android.intent.action.PACKAGE_ADDED"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    const-string v0, "install"

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/a/a/d;->b:Landroid/content/pm/PackageManager;

    const/4 v4, 0x0

    invoke-virtual {v1, v2, v4}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v1

    iget-object v1, v1, Landroid/content/pm/PackageInfo;->versionName:Ljava/lang/String;

    new-instance v4, Lcom/igexin/push/extension/distribution/gbd/b/a;

    invoke-direct {v4}, Lcom/igexin/push/extension/distribution/gbd/b/a;-><init>()V

    invoke-virtual {v4, v3}, Lcom/igexin/push/extension/distribution/gbd/b/a;->b(Ljava/lang/String;)V

    invoke-virtual {v4, v2}, Lcom/igexin/push/extension/distribution/gbd/b/a;->a(Ljava/lang/String;)V

    invoke-virtual {v4, v1}, Lcom/igexin/push/extension/distribution/gbd/b/a;->c(Ljava/lang/String;)V

    sget-object v5, Lcom/igexin/push/extension/distribution/gbd/c/c;->l:Ljava/util/Map;

    invoke-interface {v5, v2, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :goto_1
    sget-object v4, Lcom/igexin/push/core/g;->r:Ljava/lang/String;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    if-nez v4, :cond_3

    :cond_1
    :goto_2
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    const-string v1, "GBD_RPRA"

    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    :cond_2
    :try_start_2
    const-string v1, "uninstall"

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->l:Ljava/util/Map;

    invoke-interface {v0, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/gbd/b/a;

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/b/a;->a()Ljava/lang/String;

    move-result-object v0

    sget-object v4, Lcom/igexin/push/extension/distribution/gbd/c/c;->l:Ljava/util/Map;

    invoke-interface {v4, v2}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    move-object v8, v1

    move-object v1, v0

    move-object v0, v8

    goto :goto_1

    :cond_3
    new-instance v4, Ljava/text/SimpleDateFormat;

    const-string v5, "yyyy-MM-dd HH:mm:ss"

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v6

    invoke-direct {v4, v5, v6}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    new-instance v5, Ljava/util/Date;

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/i/e;->k()J

    move-result-wide v6

    invoke-direct {v5, v6, v7}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v4, v5}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v4

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v4, "|"

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    sget-object v4, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v4, "|"

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    sget-object v4, Lcom/igexin/push/core/g;->a:Ljava/lang/String;

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v4, "|"

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v3, "|"

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, "|"

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, "|"

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, "|"

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, "ANDROID"

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/e/a/b;->a()Lcom/igexin/push/extension/distribution/gbd/e/a/b;

    move-result-object v1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/gbd/a/a/d;->b()I

    move-result v2

    invoke-virtual {v1, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/b;->a(Ljava/lang/String;I)V

    const-string v1, "GBD_RPRA"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "save type = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/gbd/a/a/d;->b()I

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ", content = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_1

    goto/16 :goto_2

    :catch_1
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto/16 :goto_2
.end method

.method public b()I
    .locals 1

    const/16 v0, 0xe

    return v0
.end method
