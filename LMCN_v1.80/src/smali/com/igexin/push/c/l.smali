.class public Lcom/igexin/push/c/l;
.super Lcom/igexin/push/c/m;

# interfaces
.implements Lcom/igexin/push/c/o;


# static fields
.field private static final e:Ljava/lang/String;

.field private static f:Lcom/igexin/push/c/l;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const-class v0, Lcom/igexin/push/c/l;

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/c/l;->e:Ljava/lang/String;

    return-void
.end method

.method private constructor <init>()V
    .locals 2

    sget-object v0, Lcom/igexin/push/core/g;->au:Ljava/lang/String;

    sget-object v1, Lcom/igexin/push/core/g;->aw:Ljava/lang/String;

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/c/m;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method public static declared-synchronized a()Lcom/igexin/push/c/l;
    .locals 2

    const-class v1, Lcom/igexin/push/c/l;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/igexin/push/c/l;->f:Lcom/igexin/push/c/l;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/c/l;

    invoke-direct {v0}, Lcom/igexin/push/c/l;-><init>()V

    sput-object v0, Lcom/igexin/push/c/l;->f:Lcom/igexin/push/c/l;

    :cond_0
    sget-object v0, Lcom/igexin/push/c/l;->f:Lcom/igexin/push/c/l;
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
.method public a(Lcom/igexin/push/c/g;Lcom/igexin/push/c/j;)V
    .locals 3

    if-eqz p2, :cond_0

    invoke-virtual {p2}, Lcom/igexin/push/c/j;->a()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_1

    :cond_0
    :goto_0
    return-void

    :cond_1
    invoke-virtual {p2}, Lcom/igexin/push/c/j;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igexin/push/c/l;->a(Ljava/lang/String;)Lcom/igexin/push/c/p;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-virtual {p0, p2}, Lcom/igexin/push/c/l;->b(Lcom/igexin/push/c/j;)V

    sget-object v1, Lcom/igexin/push/c/g;->a:Lcom/igexin/push/c/g;

    if-ne p1, v1, :cond_2

    invoke-virtual {v0}, Lcom/igexin/push/c/p;->g()V

    invoke-virtual {v0}, Lcom/igexin/push/c/p;->j()V

    invoke-virtual {p0}, Lcom/igexin/push/c/l;->k()V

    invoke-virtual {p0}, Lcom/igexin/push/c/l;->n()V

    goto :goto_0

    :cond_2
    sget-object v1, Lcom/igexin/push/c/g;->c:Lcom/igexin/push/c/g;

    if-eq p1, v1, :cond_3

    sget-object v1, Lcom/igexin/push/c/g;->b:Lcom/igexin/push/c/g;

    if-ne p1, v1, :cond_0

    :cond_3
    invoke-virtual {p0}, Lcom/igexin/push/c/l;->o()V

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v2, Lcom/igexin/push/c/l;->e:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "|detect"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p0, p2}, Lcom/igexin/push/c/l;->c(Lcom/igexin/push/c/j;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "failed --------"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/igexin/push/c/l;->q()Z

    move-result v1

    if-eqz v1, :cond_4

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v2, Lcom/igexin/push/c/l;->e:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "|pool is not empty, detect task "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p0, p2}, Lcom/igexin/push/c/l;->c(Lcom/igexin/push/c/j;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "stop"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-virtual {v0}, Lcom/igexin/push/c/p;->g()V

    goto :goto_0

    :cond_4
    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/igexin/push/c/p;->a(Z)V

    goto/16 :goto_0
.end method

.method public a(Lcom/igexin/push/c/j;)V
    .locals 0

    return-void
.end method

.method public b()Lcom/igexin/push/c/h;
    .locals 1

    sget-object v0, Lcom/igexin/push/c/h;->b:Lcom/igexin/push/c/h;

    return-object v0
.end method

.method public c()Lcom/igexin/push/c/o;
    .locals 0

    return-object p0
.end method
