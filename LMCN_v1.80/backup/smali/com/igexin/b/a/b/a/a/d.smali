.class public final Lcom/igexin/b/a/b/a/a/d;
.super Ljava/lang/Object;


# static fields
.field private static final e:Ljava/lang/String;

.field private static m:Lcom/igexin/b/a/b/a/a/d;

.field private static final n:Ljava/lang/Object;


# instance fields
.field public a:Ljava/util/concurrent/locks/Lock;

.field public b:Ljava/util/concurrent/locks/Condition;

.field public c:Ljava/util/concurrent/ConcurrentLinkedQueue;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/concurrent/ConcurrentLinkedQueue",
            "<",
            "Lcom/igexin/b/a/b/a/a/k;",
            ">;"
        }
    .end annotation
.end field

.field public d:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/igexin/b/a/b/a/a/k;",
            ">;"
        }
    .end annotation
.end field

.field private f:Lcom/igexin/b/a/b/b;

.field private g:Lcom/igexin/b/a/b/d;

.field private h:Ljava/net/Socket;

.field private i:Lcom/igexin/b/a/b/a/a/j;

.field private j:Lcom/igexin/b/a/b/a/a/l;

.field private k:Lcom/igexin/b/a/b/a/a/c;

.field private l:Z

.field private o:Lcom/igexin/b/a/b/a/a/i;

.field private p:J

.field private final q:Ljava/util/Comparator;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Comparator",
            "<",
            "Lcom/igexin/b/a/b/a/a/k;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const-class v0, Lcom/igexin/b/a/b/a/a/d;

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    sput-object v0, Lcom/igexin/b/a/b/a/a/d;->n:Ljava/lang/Object;

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Ljava/util/concurrent/locks/ReentrantLock;

    invoke-direct {v0}, Ljava/util/concurrent/locks/ReentrantLock;-><init>()V

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->a:Ljava/util/concurrent/locks/Lock;

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->a:Ljava/util/concurrent/locks/Lock;

    invoke-interface {v0}, Ljava/util/concurrent/locks/Lock;->newCondition()Ljava/util/concurrent/locks/Condition;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->b:Ljava/util/concurrent/locks/Condition;

    new-instance v0, Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-direct {v0}, Ljava/util/concurrent/ConcurrentLinkedQueue;-><init>()V

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->c:Ljava/util/concurrent/ConcurrentLinkedQueue;

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    new-instance v0, Lcom/igexin/b/a/b/a/a/h;

    invoke-direct {v0, p0}, Lcom/igexin/b/a/b/a/a/h;-><init>(Lcom/igexin/b/a/b/a/a/d;)V

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->q:Ljava/util/Comparator;

    new-instance v0, Lcom/igexin/b/a/b/a/a/i;

    invoke-direct {v0, p0}, Lcom/igexin/b/a/b/a/a/i;-><init>(Lcom/igexin/b/a/b/a/a/d;)V

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->o:Lcom/igexin/b/a/b/a/a/i;

    return-void
.end method

.method public static declared-synchronized a()Lcom/igexin/b/a/b/a/a/d;
    .locals 2

    const-class v1, Lcom/igexin/b/a/b/a/a/d;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/igexin/b/a/b/a/a/d;->m:Lcom/igexin/b/a/b/a/a/d;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/b/a/b/a/a/d;

    invoke-direct {v0}, Lcom/igexin/b/a/b/a/a/d;-><init>()V

    sput-object v0, Lcom/igexin/b/a/b/a/a/d;->m:Lcom/igexin/b/a/b/a/a/d;

    :cond_0
    sget-object v0, Lcom/igexin/b/a/b/a/a/d;->m:Lcom/igexin/b/a/b/a/a/d;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v1

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method

.method static synthetic a(Lcom/igexin/b/a/b/a/a/d;Lcom/igexin/b/a/b/a/a/k;)V
    .locals 0

    invoke-direct {p0, p1}, Lcom/igexin/b/a/b/a/a/d;->b(Lcom/igexin/b/a/b/a/a/k;)V

    return-void
.end method

.method static synthetic a(Lcom/igexin/b/a/b/a/a/d;Ljava/net/Socket;)V
    .locals 0

    invoke-direct {p0, p1}, Lcom/igexin/b/a/b/a/a/d;->a(Ljava/net/Socket;)V

    return-void
.end method

.method private a(Ljava/net/Socket;)V
    .locals 3

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->k:Lcom/igexin/b/a/b/a/a/c;

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/c;->g()Z

    move-result v0

    if-eqz v0, :cond_0

    :goto_0
    return-void

    :cond_0
    iput-object p1, p0, Lcom/igexin/b/a/b/a/a/d;->h:Ljava/net/Socket;

    new-instance v0, Lcom/igexin/b/a/b/d;

    invoke-direct {v0}, Lcom/igexin/b/a/b/d;-><init>()V

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->g:Lcom/igexin/b/a/b/d;

    invoke-direct {p0, p1}, Lcom/igexin/b/a/b/a/a/d;->b(Ljava/net/Socket;)V

    invoke-direct {p0, p1}, Lcom/igexin/b/a/b/a/a/d;->c(Ljava/net/Socket;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v2, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "|"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/igexin/b/a/b/a/a/d;->b()V

    goto :goto_0
.end method

.method static synthetic a(Lcom/igexin/b/a/b/a/a/d;)Z
    .locals 1

    invoke-direct {p0}, Lcom/igexin/b/a/b/a/a/d;->k()Z

    move-result v0

    return v0
.end method

.method static synthetic a(Lcom/igexin/b/a/b/a/a/d;Z)Z
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/b/a/b/a/a/d;->l:Z

    return p1
.end method

.method static synthetic b(Lcom/igexin/b/a/b/a/a/d;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/b/a/b/a/a/d;->f()V

    return-void
.end method

.method private b(Lcom/igexin/b/a/b/a/a/k;)V
    .locals 8

    iget v0, p1, Lcom/igexin/b/a/b/a/a/k;->y:I

    if-lez v0, :cond_0

    iget-object v0, p1, Lcom/igexin/b/a/b/a/a/k;->D:Lcom/igexin/b/a/d/a/f;

    if-nez v0, :cond_1

    :cond_0
    invoke-virtual {p1}, Lcom/igexin/b/a/b/a/a/k;->p()V

    :goto_0
    return-void

    :cond_1
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    invoke-virtual {p1, v2, v3}, Lcom/igexin/b/a/b/a/a/k;->b(J)V

    sget-object v1, Lcom/igexin/b/a/b/a/a/d;->n:Ljava/lang/Object;

    monitor-enter v1

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    iget-object v4, p0, Lcom/igexin/b/a/b/a/a/d;->q:Ljava/util/Comparator;

    invoke-static {v0, v4}, Ljava/util/Collections;->sort(Ljava/util/List;Ljava/util/Comparator;)V

    sget-object v4, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    const/4 v5, 0x0

    invoke-interface {v0, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/b/a/b/a/a/k;

    iget v0, v0, Lcom/igexin/b/a/b/a/a/k;->y:I

    int-to-long v6, v0

    invoke-virtual {v4, v6, v7}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide v4

    iput-wide v4, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    iget-wide v4, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    const-wide/16 v6, 0x0

    cmp-long v0, v4, v6

    if-lez v0, :cond_2

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    const/4 v4, 0x1

    if-ne v0, v4, :cond_2

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v4, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "|add : "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, " --- "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v4, p1, Lcom/igexin/b/a/b/a/a/k;->c:Ljava/lang/Object;

    invoke-virtual {v4}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, " set alarm "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "delay = "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-wide v4, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    sget-wide v6, Lcom/igexin/b/a/d/e;->u:J

    add-long/2addr v4, v6

    invoke-virtual {v0, v4, v5}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    iget-wide v4, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    add-long/2addr v2, v4

    sget-wide v4, Lcom/igexin/b/a/d/e;->u:J

    add-long/2addr v2, v4

    invoke-virtual {v0, v2, v3}, Lcom/igexin/b/a/b/c;->b(J)V

    :cond_2
    monitor-exit v1

    goto/16 :goto_0

    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method private b(Ljava/net/Socket;)V
    .locals 4

    new-instance v0, Lcom/igexin/b/a/b/a/a/j;

    new-instance v1, Lcom/igexin/b/a/b/a/a/m;

    invoke-virtual {p1}, Ljava/net/Socket;->getInputStream()Ljava/io/InputStream;

    move-result-object v2

    invoke-direct {v1, v2}, Lcom/igexin/b/a/b/a/a/m;-><init>(Ljava/io/InputStream;)V

    iget-object v2, p0, Lcom/igexin/b/a/b/a/a/d;->f:Lcom/igexin/b/a/b/b;

    iget-object v3, p0, Lcom/igexin/b/a/b/a/a/d;->g:Lcom/igexin/b/a/b/d;

    invoke-direct {v0, v1, v2, v3}, Lcom/igexin/b/a/b/a/a/j;-><init>(Lcom/igexin/b/a/b/a/a/m;Lcom/igexin/b/a/b/b;Lcom/igexin/b/a/b/d;)V

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    new-instance v1, Lcom/igexin/b/a/b/a/a/f;

    invoke-direct {v1, p0}, Lcom/igexin/b/a/b/a/a/f;-><init>(Lcom/igexin/b/a/b/a/a/d;)V

    invoke-virtual {v0, v1}, Lcom/igexin/b/a/b/a/a/j;->a(Lcom/igexin/b/a/b/a/a/a/b;)V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    const/4 v2, 0x1

    invoke-virtual {v0, v1, v2}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;Z)Z

    return-void
.end method

.method private c(Ljava/net/Socket;)V
    .locals 4

    new-instance v0, Lcom/igexin/b/a/b/a/a/l;

    new-instance v1, Lcom/igexin/b/a/b/a/a/n;

    invoke-virtual {p1}, Ljava/net/Socket;->getOutputStream()Ljava/io/OutputStream;

    move-result-object v2

    invoke-direct {v1, v2}, Lcom/igexin/b/a/b/a/a/n;-><init>(Ljava/io/OutputStream;)V

    iget-object v2, p0, Lcom/igexin/b/a/b/a/a/d;->f:Lcom/igexin/b/a/b/b;

    iget-object v3, p0, Lcom/igexin/b/a/b/a/a/d;->g:Lcom/igexin/b/a/b/d;

    invoke-direct {v0, v1, v2, v3}, Lcom/igexin/b/a/b/a/a/l;-><init>(Lcom/igexin/b/a/b/a/a/n;Lcom/igexin/b/a/b/b;Lcom/igexin/b/a/b/d;)V

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    new-instance v1, Lcom/igexin/b/a/b/a/a/g;

    invoke-direct {v1, p0}, Lcom/igexin/b/a/b/a/a/g;-><init>(Lcom/igexin/b/a/b/a/a/d;)V

    invoke-virtual {v0, v1}, Lcom/igexin/b/a/b/a/a/l;->a(Lcom/igexin/b/a/b/a/a/a/c;)V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    const/4 v2, 0x1

    invoke-virtual {v0, v1, v2}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;Z)Z

    return-void
.end method

.method static synthetic c(Lcom/igexin/b/a/b/a/a/d;)Z
    .locals 1

    invoke-direct {p0}, Lcom/igexin/b/a/b/a/a/d;->j()Z

    move-result v0

    return v0
.end method

.method static synthetic d(Lcom/igexin/b/a/b/a/a/d;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/b/a/b/a/a/d;->h()V

    return-void
.end method

.method static synthetic e()Ljava/lang/String;
    .locals 1

    sget-object v0, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    return-object v0
.end method

.method static synthetic e(Lcom/igexin/b/a/b/a/a/d;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/b/a/b/a/a/d;->l()V

    return-void
.end method

.method static synthetic f(Lcom/igexin/b/a/b/a/a/d;)Lcom/igexin/b/a/b/a/a/c;
    .locals 1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->k:Lcom/igexin/b/a/b/a/a/c;

    return-object v0
.end method

.method private f()V
    .locals 3

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|disconnect = true, reconnect"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    new-instance v0, Lcom/igexin/b/a/b/a/a/c;

    new-instance v1, Lcom/igexin/b/a/b/a/a/e;

    invoke-direct {v1, p0}, Lcom/igexin/b/a/b/a/a/e;-><init>(Lcom/igexin/b/a/b/a/a/d;)V

    invoke-direct {v0, v1}, Lcom/igexin/b/a/b/a/a/c;-><init>(Lcom/igexin/b/a/b/a/a/a/d;)V

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->k:Lcom/igexin/b/a/b/a/a/c;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->k:Lcom/igexin/b/a/b/a/a/c;

    const/4 v2, 0x1

    invoke-virtual {v0, v1, v2}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;Z)Z

    return-void
.end method

.method static synthetic g(Lcom/igexin/b/a/b/a/a/d;)Lcom/igexin/b/a/b/a/a/l;
    .locals 1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    return-object v0
.end method

.method private g()V
    .locals 2

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|disconnect"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->k:Lcom/igexin/b/a/b/a/a/c;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->k:Lcom/igexin/b/a/b/a/a/c;

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/c;->h()V

    :cond_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/l;->h()V

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/l;->j:Lcom/igexin/b/a/b/a/a/n;

    if-eqz v0, :cond_1

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/l;->j:Lcom/igexin/b/a/b/a/a/n;

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/n;->a()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_2

    :cond_1
    :goto_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/j;->h()V

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/j;->i:Lcom/igexin/b/a/b/a/a/m;

    if-eqz v0, :cond_2

    :try_start_1
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/j;->i:Lcom/igexin/b/a/b/a/a/m;

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/m;->a()V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    :cond_2
    :goto_1
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->h:Ljava/net/Socket;

    if-eqz v0, :cond_3

    :try_start_2
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->h:Ljava/net/Socket;

    invoke-virtual {v0}, Ljava/net/Socket;->isClosed()Z

    move-result v0

    if-nez v0, :cond_3

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->h:Ljava/net/Socket;

    invoke-virtual {v0}, Ljava/net/Socket;->close()V
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_0

    :cond_3
    :goto_2
    return-void

    :catch_0
    move-exception v0

    goto :goto_2

    :catch_1
    move-exception v0

    goto :goto_1

    :catch_2
    move-exception v0

    goto :goto_0
.end method

.method static synthetic h(Lcom/igexin/b/a/b/a/a/d;)Lcom/igexin/b/a/b/a/a/j;
    .locals 1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    return-object v0
.end method

.method private h()V
    .locals 2

    iget-boolean v0, p0, Lcom/igexin/b/a/b/a/a/d;->l:Z

    if-nez v0, :cond_0

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/b/a/b/a/a/d;->l:Z

    invoke-direct {p0}, Lcom/igexin/b/a/b/a/a/d;->i()V

    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v0

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/igexin/push/core/a/e;->b(Z)V

    :cond_0
    return-void
.end method

.method private i()V
    .locals 2

    const/4 v1, 0x0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    iput-object v1, v0, Lcom/igexin/b/a/b/a/a/l;->j:Lcom/igexin/b/a/b/a/a/n;

    iput-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    :cond_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    iput-object v1, v0, Lcom/igexin/b/a/b/a/a/j;->i:Lcom/igexin/b/a/b/a/a/m;

    iput-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    :cond_1
    iput-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->k:Lcom/igexin/b/a/b/a/a/c;

    iput-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->h:Ljava/net/Socket;

    iput-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->g:Lcom/igexin/b/a/b/d;

    return-void
.end method

.method static synthetic i(Lcom/igexin/b/a/b/a/a/d;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/b/a/b/a/a/d;->g()V

    return-void
.end method

.method static synthetic j(Lcom/igexin/b/a/b/a/a/d;)Lcom/igexin/b/a/b/a/a/i;
    .locals 1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->o:Lcom/igexin/b/a/b/a/a/i;

    return-object v0
.end method

.method private j()Z
    .locals 1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->k:Lcom/igexin/b/a/b/a/a/c;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->k:Lcom/igexin/b/a/b/a/a/c;

    iget-boolean v0, v0, Lcom/igexin/b/a/b/a/a/c;->e:Z

    if-eqz v0, :cond_2

    :cond_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    iget-boolean v0, v0, Lcom/igexin/b/a/b/a/a/j;->e:Z

    if-eqz v0, :cond_2

    :cond_1
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    if-eqz v0, :cond_3

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    iget-boolean v0, v0, Lcom/igexin/b/a/b/a/a/l;->e:Z

    if-nez v0, :cond_3

    :cond_2
    const/4 v0, 0x0

    :goto_0
    return v0

    :cond_3
    const/4 v0, 0x1

    goto :goto_0
.end method

.method private k()Z
    .locals 1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->h:Ljava/net/Socket;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->h:Ljava/net/Socket;

    invoke-virtual {v0}, Ljava/net/Socket;->isClosed()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private l()V
    .locals 3

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/b/a/b/c;->e()V

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|cancel alrm"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    sget-object v1, Lcom/igexin/b/a/b/a/a/d;->n:Ljava/lang/Object;

    monitor-enter v1

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/b/a/b/a/a/k;

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/k;->p()V

    goto :goto_0

    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0

    :cond_0
    :try_start_1
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->clear()V

    :cond_1
    monitor-exit v1
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    sget-object v0, Lcom/igexin/b/a/b/a/a/d;->m:Lcom/igexin/b/a/b/a/a/d;

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/d;->c:Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-virtual {v0}, Ljava/util/concurrent/ConcurrentLinkedQueue;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_3

    sget-object v0, Lcom/igexin/b/a/b/a/a/d;->m:Lcom/igexin/b/a/b/a/a/d;

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/d;->c:Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-virtual {v0}, Ljava/util/concurrent/ConcurrentLinkedQueue;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_1
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/b/a/b/a/a/k;

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/k;->p()V

    goto :goto_1

    :cond_2
    sget-object v0, Lcom/igexin/b/a/b/a/a/d;->m:Lcom/igexin/b/a/b/a/a/d;

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/d;->c:Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-virtual {v0}, Ljava/util/concurrent/ConcurrentLinkedQueue;->clear()V

    :cond_3
    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/b/a/b/a/a/k;)V
    .locals 2

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->a:Ljava/util/concurrent/locks/Lock;

    invoke-interface {v0}, Ljava/util/concurrent/locks/Lock;->lock()V

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->c:Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-virtual {v0, p1}, Ljava/util/concurrent/ConcurrentLinkedQueue;->offer(Ljava/lang/Object;)Z

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->b:Ljava/util/concurrent/locks/Condition;

    invoke-interface {v0}, Ljava/util/concurrent/locks/Condition;->signalAll()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    :try_start_1
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->a:Ljava/util/concurrent/locks/Lock;

    invoke-interface {v0}, Ljava/util/concurrent/locks/Lock;->unlock()V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_3

    :goto_0
    return-void

    :catch_0
    move-exception v0

    :try_start_2
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->a:Ljava/util/concurrent/locks/Lock;

    invoke-interface {v0}, Ljava/util/concurrent/locks/Lock;->unlock()V
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_1

    goto :goto_0

    :catch_1
    move-exception v0

    goto :goto_0

    :catchall_0
    move-exception v0

    :try_start_3
    iget-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->a:Ljava/util/concurrent/locks/Lock;

    invoke-interface {v1}, Ljava/util/concurrent/locks/Lock;->unlock()V
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_2

    :goto_1
    throw v0

    :catch_2
    move-exception v1

    goto :goto_1

    :catch_3
    move-exception v0

    goto :goto_0
.end method

.method public a(Lcom/igexin/b/a/b/b;)V
    .locals 1

    iput-object p1, p0, Lcom/igexin/b/a/b/a/a/d;->f:Lcom/igexin/b/a/b/b;

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->i:Lcom/igexin/b/a/b/a/a/j;

    iput-object p1, v0, Lcom/igexin/b/a/b/a/a/j;->j:Lcom/igexin/b/a/b/b;

    :cond_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->j:Lcom/igexin/b/a/b/a/a/l;

    iput-object p1, v0, Lcom/igexin/b/a/b/a/a/l;->i:Lcom/igexin/b/a/b/b;

    :cond_1
    return-void
.end method

.method public a(Ljava/lang/String;)V
    .locals 12

    const-wide/16 v10, 0x0

    const/4 v1, 0x0

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    sget-object v4, Lcom/igexin/b/a/b/a/a/d;->n:Ljava/lang/Object;

    monitor-enter v4

    :try_start_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v5, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|"

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, " -- resp"

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v5

    :cond_0
    :goto_0
    invoke-interface {v5}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_6

    invoke-interface {v5}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/b/a/b/a/a/k;

    iget-object v6, v0, Lcom/igexin/b/a/b/a/a/k;->D:Lcom/igexin/b/a/d/a/f;

    invoke-interface {v6, v2, v3, v0}, Lcom/igexin/b/a/d/a/f;->a(JLcom/igexin/b/a/d/d;)Z

    move-result v6

    if-eqz v6, :cond_1

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/k;->p()V

    iget-object v1, v0, Lcom/igexin/b/a/b/a/a/k;->D:Lcom/igexin/b/a/d/a/f;

    invoke-interface {v1, v0}, Lcom/igexin/b/a/d/a/f;->a(Lcom/igexin/b/a/d/d;)V

    const/4 v0, 0x1

    invoke-interface {v5}, Ljava/util/Iterator;->remove()V

    :goto_1
    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/b/a/b/c;->e()V

    if-eqz v0, :cond_3

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|time out"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/igexin/b/a/b/a/a/d;->d()V

    monitor-exit v4

    :goto_2
    return-void

    :cond_1
    iget-object v6, v0, Lcom/igexin/b/a/b/a/a/k;->D:Lcom/igexin/b/a/d/a/f;

    invoke-interface {v6, v2, v3, v0}, Lcom/igexin/b/a/d/a/f;->b(JLcom/igexin/b/a/d/d;)J

    move-result-wide v6

    iget-wide v8, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    cmp-long v0, v8, v10

    if-ltz v0, :cond_2

    iget-wide v8, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    cmp-long v0, v8, v6

    if-lez v0, :cond_0

    :cond_2
    iput-wide v6, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    goto :goto_0

    :catchall_0
    move-exception v0

    monitor-exit v4
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0

    :cond_3
    :try_start_1
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    if-lez v0, :cond_4

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    const/4 v1, 0x0

    invoke-interface {v0, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/b/a/b/a/a/k;

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/k;->p()V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/igexin/b/a/b/c;->a(Ljava/lang/Object;)Z

    iget-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    invoke-interface {v1, v0}, Ljava/util/List;->remove(Ljava/lang/Object;)Z

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v5, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v1, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v5, "|remove : "

    invoke-virtual {v1, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v1, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v5, " -- "

    invoke-virtual {v1, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/k;->c:Ljava/lang/Object;

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    :cond_4
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->d:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v5, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v1, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v5, "|r, size = "

    invoke-virtual {v1, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    if-lez v0, :cond_5

    iget-wide v0, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    cmp-long v0, v0, v10

    if-lez v0, :cond_5

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|set alarm = "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-wide v6, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    invoke-virtual {v0, v6, v7}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    iget-wide v6, p0, Lcom/igexin/b/a/b/a/a/d;->p:J

    add-long/2addr v2, v6

    sget-wide v6, Lcom/igexin/b/a/d/e;->u:J

    add-long/2addr v2, v6

    invoke-virtual {v0, v2, v3}, Lcom/igexin/b/a/b/c;->b(J)V

    :cond_5
    monitor-exit v4
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto/16 :goto_2

    :cond_6
    move v0, v1

    goto/16 :goto_1
.end method

.method public declared-synchronized a(Z)V
    .locals 2

    monitor-enter p0

    :try_start_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|reconnect, reset = "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-static {}, Landroid/os/Message;->obtain()Landroid/os/Message;

    move-result-object v0

    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v1

    iput-object v1, v0, Landroid/os/Message;->obj:Ljava/lang/Object;

    const/4 v1, 0x5

    iput v1, v0, Landroid/os/Message;->what:I

    iget-object v1, p0, Lcom/igexin/b/a/b/a/a/d;->o:Lcom/igexin/b/a/b/a/a/i;

    invoke-virtual {v1, v0}, Lcom/igexin/b/a/b/a/a/i;->sendMessage(Landroid/os/Message;)Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized b()V
    .locals 2

    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->o:Lcom/igexin/b/a/b/a/a/i;

    const/4 v1, 0x4

    invoke-virtual {v0, v1}, Lcom/igexin/b/a/b/a/a/i;->sendEmptyMessage(I)Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public c()V
    .locals 2

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->o:Lcom/igexin/b/a/b/a/a/i;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/igexin/b/a/b/a/a/i;->sendEmptyMessage(I)Z

    return-void
.end method

.method public declared-synchronized d()V
    .locals 2

    monitor-enter p0

    :try_start_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/b/a/b/a/a/d;->e:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|alarm timeout disconnect"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/d;->o:Lcom/igexin/b/a/b/a/a/i;

    const/4 v1, 0x4

    invoke-virtual {v0, v1}, Lcom/igexin/b/a/b/a/a/i;->sendEmptyMessage(I)Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method
