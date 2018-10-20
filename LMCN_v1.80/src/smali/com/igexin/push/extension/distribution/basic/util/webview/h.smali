.class public Lcom/igexin/push/extension/distribution/basic/util/webview/h;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/igexin/b/a/d/a/b;


# static fields
.field private static a:Lcom/igexin/push/extension/distribution/basic/util/webview/h;


# instance fields
.field private b:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Lcom/igexin/push/extension/distribution/basic/util/webview/g;",
            ">;"
        }
    .end annotation
.end field

.field private c:Lcom/igexin/b/a/b/c;


# direct methods
.method public constructor <init>(Lcom/igexin/b/a/b/c;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->c:Lcom/igexin/b/a/b/c;

    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->b:Ljava/util/Map;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->c:Lcom/igexin/b/a/b/c;

    invoke-virtual {v0, p0}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/a/b;)Z

    return-void
.end method

.method public static declared-synchronized a(Lcom/igexin/b/a/b/c;)Lcom/igexin/push/extension/distribution/basic/util/webview/h;
    .locals 2

    const-class v1, Lcom/igexin/push/extension/distribution/basic/util/webview/h;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->a:Lcom/igexin/push/extension/distribution/basic/util/webview/h;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;

    invoke-direct {v0, p0}, Lcom/igexin/push/extension/distribution/basic/util/webview/h;-><init>(Lcom/igexin/b/a/b/c;)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->a:Lcom/igexin/push/extension/distribution/basic/util/webview/h;

    :cond_0
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->a:Lcom/igexin/push/extension/distribution/basic/util/webview/h;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v1

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method


# virtual methods
.method public a(Lcom/igexin/b/a/d/a/e;Lcom/igexin/b/a/d/e;)Z
    .locals 3

    const/4 v0, 0x0

    invoke-interface {p1}, Lcom/igexin/b/a/d/a/e;->b()I

    move-result v1

    sparse-switch v1, :sswitch_data_0

    move-object v1, v0

    :goto_0
    if-eqz v1, :cond_1

    invoke-virtual {v1, p1, p2}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a(Lcom/igexin/b/a/d/a/e;Lcom/igexin/b/a/d/e;)Z

    move-result v0

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a()Z

    move-result v2

    if-eqz v2, :cond_0

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->b:Ljava/util/Map;

    iget-object v1, v1, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->e:Ljava/lang/String;

    invoke-interface {v2, v1}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    :cond_0
    :goto_1
    return v0

    :sswitch_0
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->b:Ljava/util/Map;

    move-object v0, p1

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->a:Ljava/lang/String;

    invoke-interface {v1, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;

    move-object v1, v0

    goto :goto_0

    :sswitch_1
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->b:Ljava/util/Map;

    move-object v0, p1

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->i:Ljava/lang/String;

    invoke-interface {v1, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;

    move-object v1, v0

    goto :goto_0

    :cond_1
    const/4 v0, 0x0

    goto :goto_1

    nop

    :sswitch_data_0
    .sparse-switch
        -0x88801 -> :sswitch_0
        0x88802 -> :sswitch_1
    .end sparse-switch
.end method

.method public a(Lcom/igexin/b/a/d/d;Lcom/igexin/b/a/d/e;)Z
    .locals 3

    const/4 v1, 0x0

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->b()I

    move-result v0

    sparse-switch v0, :sswitch_data_0

    :cond_0
    :goto_0
    if-eqz v1, :cond_2

    invoke-virtual {v1, p1, p2}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a(Lcom/igexin/b/a/d/d;Lcom/igexin/b/a/d/e;)Z

    move-result v0

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a()Z

    move-result v2

    if-eqz v2, :cond_1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->b:Ljava/util/Map;

    iget-object v1, v1, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->e:Ljava/lang/String;

    invoke-interface {v2, v1}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    :cond_1
    :goto_1
    return v0

    :sswitch_0
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->b:Ljava/util/Map;

    move-object v0, p1

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->a:Ljava/lang/String;

    invoke-interface {v1, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;

    move-object v1, v0

    goto :goto_0

    :sswitch_1
    move-object v0, p1

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/h/a;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/h/a;->a:Lcom/igexin/push/extension/distribution/basic/h/f;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/h/f;->b()I

    move-result v2

    packed-switch v2, :pswitch_data_0

    goto :goto_0

    :pswitch_0
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->b:Ljava/util/Map;

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->i:Ljava/lang/String;

    invoke-interface {v1, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;

    move-object v1, v0

    goto :goto_0

    :cond_2
    const/4 v0, 0x0

    goto :goto_1

    :sswitch_data_0
    .sparse-switch
        -0x7ffffff7 -> :sswitch_1
        -0x88801 -> :sswitch_0
    .end sparse-switch

    :pswitch_data_0
    .packed-switch 0x88802
        :pswitch_0
    .end packed-switch
.end method

.method public a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/util/webview/e;)Z
    .locals 8

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;

    iget-object v5, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->c:Lcom/igexin/b/a/b/c;

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move v6, p5

    move-object v7, p6

    invoke-direct/range {v0 .. v7}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/b/a/b/c;ILcom/igexin/push/extension/distribution/basic/util/webview/e;)V

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->b()V

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->b:Ljava/util/Map;

    invoke-interface {v1, p3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    if-nez v1, :cond_0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/h;->b:Ljava/util/Map;

    invoke-interface {v1, p3, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public n()Z
    .locals 1

    const/4 v0, 0x1

    return v0
.end method

.method public o()J
    .locals 2

    const-wide/32 v0, -0x13579

    return-wide v0
.end method
